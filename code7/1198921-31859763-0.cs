    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace PGenCore
    {
        /// <summary>
        /// TODO: test different field retreival techniques (using fields from T, and managing in a Dictionary)
        ///  - how would we define defaults?
        ///
        ///
        /// Usage:
        ///   dynamic objectBuilder = new ObjectBuilder();
        ///   var object = objectBuilder
        ///     .WithObjectFieldName(appropriateValue)
        ///     .WithObjectField(appropriateValue2)
        ///     .Build();
        ///
        /// </summary>
        /// <typeparam name="T">Type to Build</typeparam>
        public class DynamicBuilder<T> : DynamicObject
        {
            #region List of FieldInformation
            protected FieldInfo[] FieldInfos;
            public FieldInfo[] FieldInformation
            {
                get
                {
                    // don't GetFields all the time
                    if (FieldInfos != null) return FieldInfos;
    
                    FieldInfos = this.GetType().GetFields(
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.Instance);
    
                    return FieldInfos;
                }
            }
            #endregion
    
            #region Utility
    
            /// <summary>
            /// converts FieldName to _fieldName
            /// </summary>
            /// <param name="publicName"></param>
            /// <returns></returns>
            public static string PublicNameToPrivate(string publicName)
            {
                var propertyLowerFirstLetterName = char.ToLower(
                    publicName[0]) + publicName.Substring(1);
    
                var privateName = "_" + propertyLowerFirstLetterName;
    
                return privateName;
            }
            #endregion
    
            #region Method is Missing? Check for With{FieldName} Pattern
    
            /// <summary>
            /// Inherited form DynamicObject.
            /// Ran before each method call.
            ///
            ///
            /// Note: Currently only works for setting one value
            ///  at a time.
            ///   e.g.: instance.Object = value
            /// </summary>
            /// <param name="binder"></param>
            /// <param name="args"></param>
            /// <param name="result"></param>
            /// <returns></returns>
            public override bool TryInvokeMember(
                 InvokeMemberBinder binder,
                 object[] args,
                 out object result)
            {
    
                var firstArgument = args[0];
                var methodName = binder.Name;
                var propertyRootName = methodName;
    
                // following the builder pattern,
                // methods that participate in building T,
                // return this so we can chain building methods.
                result = this;
    
                // for booleans, since the field / property should be named as
                // a question, using "With" doesn't make sense.
                // so, this logic is only needed when we are not setting a
                // boolean field.
                if (!(firstArgument is bool))
                {
                    // if we are not setting a bool, and we aren't starting
                    // with "With", this method is not part of the
                    // fluent builder pattern.
                    if (!methodName.Contains("With")) return false;
                    propertyRootName = methodName.Replace("With", "");
                }
    
                // convert to _privateFieldName
                // TODO: think about dynamicly having fields in a Dictionary,
                //  rather than having to specify them
                var builderFieldName = PublicNameToPrivate(propertyRootName);
    
                // find matching field name, given the method name
                var fieldInfo = FieldInformation
                    .FirstOrDefault(
                        field => field.Name == builderFieldName
                     );
    
                // if the field was not found, abort
                if (fieldInfo == null) return false;
    
                // set the field to the value in args
                fieldInfo.SetValue(this, firstArgument);
                return true;
            }
    
            #endregion
    
            /// <summary>
            /// Returns the built object
            /// </summary>
            /// <returns></returns>
            public virtual T Build()
            {
                throw new NotImplementedException();
            }
    
            /// <summary>
            /// for any complex associations
            /// - building lists of items
            /// - building anything else that isn't just an easy vavlue.
            /// </summary>
            public virtual void SetRelationshipDefaults()
            {
                throw new NotImplementedException();
            }
        }
    }
