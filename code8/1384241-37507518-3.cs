    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    
    namespace PGSolutions.Utilities.Monads {
        using static Contract;
    
        /// <summary>An immutable value-type MaybeX{T} monad.</summary>
        /// <typeparam name="TValue">The base type, which can be either a class or struct type,
        /// and will have the Equality definition track the default for the base-type:
        /// Value-equality for structs and string, reference equality for other classes.
        /// </typeparam>
        /// <remarks
        /// >Being a value-type reduces memory pressure on <see cref="System.GC"/>.
        /// 
        /// Equality tracks the base type (struct or class), with the further proviseo
        /// that two instances can only be equal when <see cref="HasValue"/> is true
        /// for both instances.
        /// </remarks>
        public struct MaybeX<T> : IEquatable<MaybeX<T>> where T:class {
            /// <summary>The Invalid Data value.</summary>
            [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
            public static MaybeX<T> Nothing { get { return default(MaybeX<T>); } }
    
            ///<summary>Create a new MaybeX{T}.</summary>
            private MaybeX(T value) : this() {
                _value    = value;
            }
    
            /// <summary>LINQ-compatible implementation of the monadic map operator.</summary>
            ///<remarks>
            /// Used to implement the LINQ <i>let</i> clause and queries with a single FROM clause.
            /// 
            /// Always available from Bind():
            ///         return @this.Bind(v => projector(v).ToMaybe());
            ///</remarks>
            public MaybeX<TResult>  Select<TResult>(
                Func<T, TResult> projector
            ) where TResult : class {
                projector.ContractedNotNull(nameof(projector));
    
                return (_value == null) ? default(MaybeX<TResult>) : projector(_value);
            }
    
            ///<summary>The monadic Bind operation of type T to type MaybeX{TResult}.</summary>
            /// <remarks>
            /// Convenience method - not used by LINQ
            /// </remarks>
            [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
            [Pure]
            public  MaybeX<TResult> SelectMany<TResult>(
                Func<T, MaybeX<TResult>> selector
            ) where TResult:class {
                selector.ContractedNotNull(nameof(selector));
    
                return (_value == null) ? default(MaybeX<TResult>) : selector(_value);
            }
    
            /// <summary>LINQ-compatible implementation of the monadic join operator.</summary>
            /// <remarks>
            /// Used for LINQ queries with multiple <i>from</i> clauses or with more complex structure.
            /// </remarks>
            [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
            public MaybeX<TResult> SelectMany<TIntermediate, TResult>(
                Func<T, MaybeX<TIntermediate>> selector,
                Func<T,TIntermediate,TResult> projector
            ) where TIntermediate:class where TResult:class {
                selector.ContractedNotNull(nameof(selector));
                projector.ContractedNotNull(nameof(projector));
    
                var @this = this;
                return (_value == null) ? default(MaybeX<TResult>)
                                        : selector(_value).Select(e => projector(@this._value, e));
            }
    
            ///<summary>Returns whether this MaybeX{T} has a value.</summary>
            public bool HasValue {
                get {
                    Ensures((_value != null) == HasValue);
                    return _value != null;
                }
            }
    
            ///<summary>Extract value of the MaybeX{T}, substituting <paramref name="defaultValue"/> as needed.</summary>
            [Pure]
            public T BitwiseOr(T defaultValue) {
                defaultValue.ContractedNotNull(nameof(defaultValue));
                Ensures(Result<T>() != null);
    
                return _value ?? defaultValue;
            }
            ///<summary>Extract value of the MaybeX{T}, substituting <paramref name="defaultValue"/> as needed.</summary>
            [Pure]
            public static T operator | (MaybeX<T> value, T defaultValue) {
                defaultValue.ContractedNotNull(nameof(defaultValue));
                Ensures(Result<T>() != null);
    
                return value.BitwiseOr(defaultValue);
            }
    
            ///<summary>The invariants enforced by this struct type.</summary>
            [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
            [ContractInvariantMethod]
            [Pure]
            private void ObjectInvariant() {
                Invariant(HasValue == (_value != null));
            }
    
            ///<summary>Wraps a T as a MaybeX{T}.</summary>
            [Pure]
            public static implicit operator MaybeX<T>(T value) => new MaybeX<T>(value);
    
            readonly T _value;
    
            #region Value Equality with IEquatable<T>.
            /// <inheritdoc/>
            [Pure]
            public override bool Equals(object obj) => (obj as MaybeX<T>?)?.Equals(this) ?? false;
    
            /// <summary>Tests value-equality, returning <b>false</b> if either value doesn't exist.</summary>
            [Pure]
            public bool Equals(MaybeX<T> other)  =>
                _value != null ? other._value != null && (_value == other._value || _value.Equals(other._value))
                               : other._value == null;
    
            ///<summary>Retrieves the hash code of the object returned by the <see cref="_value"/> property.</summary>
            [Pure]
            public override int GetHashCode() => (_value == null) ? 0 : _value.GetHashCode();
    
            /// <summary>Tests value-equality, returning false if either value doesn't exist.</summary>
            [Pure]
            public static bool operator == (MaybeX<T> lhs, MaybeX<T> rhs) => lhs.Equals(rhs);
    
            /// <summary>Tests value-inequality, returning false if either value doesn't exist..</summary>
            [Pure]
            public static bool operator != (MaybeX<T> lhs, MaybeX<T> rhs) => ! lhs.Equals(rhs);
    
            ///<summary>Tests value-equality, returning <see cref="null"/> if either value doesn't exist.</summary>
            [Pure]
            public bool? AreNonNullEqual(MaybeX<T> rhs) =>
                this.HasValue && rhs.HasValue ? this._value.Equals(rhs._value)
                                              : null as bool?;
    
            ///<summary>Tests value-equality, returning <see cref="null"/> if either value doesn't exist.</summary>
            [Pure]
            public bool? AreNonNullUnequal(MaybeX<T> rhs) =>
                this.HasValue && rhs.HasValue ? ! this._value.Equals(rhs._value)
                                              : null as bool?;
            #endregion
    
            /// <inheritdoc/>
            [Pure]
            public override string ToString() {
                Ensures(Result<string>() != null);
                return SelectMany<string>(v => v.ToString()) | "";
            }
        }
    
        [Pure]
        public static class MaybeX {
            ///<summary>Amplifies a reference-type T to a MaybeX{T}.</summary>
            ///<remarks>The monad <i>unit</i> function.</remarks>
            public static MaybeX<T> AsMaybeX<T>(this T @this) where T:class => @this;
    
            ///<summary>Amplifies a reference-type T to a MaybeX{T}.</summary>
            ///<remarks>The monad <i>unit</i> function.</remarks>
            public static MaybeX<object> ToMaybeX<T>(this T @this) where T : struct => @this;
    
            ///<summary>Returns the type of the underlying type {TValue}.</summary>
            [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this")]
            public static Type GetUnderlyingType<T>(this MaybeX<T> @this) where T:class {
                Ensures(Result<System.Type>() != null);
                return typeof(T);
            }
    
            public static MaybeX<T> Cast<T>(this MaybeX<object> @this) where T:class =>
                from o in @this select (T)o;
        }
    }
