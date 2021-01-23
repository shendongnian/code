    /// <summary>
    /// Wraps a flags enum value.
    /// </summary>
    /// <remarks>
    /// This class is meant to be used in conjunction with 
    /// <see cref="FlagsConverter{TFlags,TEnum}"/> and simply boxes an enum.
    /// This is necessary in order to customize WCF's default behavior for enum
    /// types (as implemented by <see cref="QueryStringConverter"/>) by using a
    /// <see cref="TypeConverter"/>.
    /// </remarks>
    /// <devdoc>
    /// We prefer this over using an 1-Tuple (<see cref="Tuple{T1} "/>) as it
    /// allows us to add constraints on the type parameter. Also, the value 
    /// wrapped by a <see cref="Tuple{T1} "/> is read-only, which we don't want
    /// here, as there is no reason to prevent [OperationContract] methods from
    /// writing the wrapped <see cref="Value"/>.
    /// </devdoc>
    /// <typeparam name="TEnum">
    /// The enum type. Must be attributed with <see cref="FlagsAttribute"/>.
    /// </typeparam>
    public abstract class Flags<TEnum>
            where TEnum : struct, IConvertible
    {
        // Use a static c'tor to add run-time checks on the type parameter that
        // cannot be checked at compile-time via constraints.
        static Flags()
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new InvalidOperationException("T is not an enum");
            }
            if (!typeof(TEnum).IsDefined(typeof(FlagsAttribute), false))
            {
                throw new InvalidOperationException("T is not a flags enum");
            }
        }
        /// <summary>
        /// The enum value.
        /// </summary>
        public TEnum Value
        {
            get;
            set;
        }
    }
    /// <summary>
    /// A <see cref="TypeConverter"/> implementation that converts from
    /// <c>string</c> to <see cref="Flags{TEnum}"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Meant to be used in conjunction with <see cref="Flags{TEnum}"/>.
    /// The purpose of this <see cref="TypeConverter"/> implementation is to
    /// convert both <c>null</c> and the empty string to <c>default(TEnum)</c>
    /// instead of throwing an exception. This way, a flags enum (wrapped in an
    /// instance of <see cref="Flags{TEnum}"/>) can be used as the type of an
    /// optional parameter in a RESTful WCF <c>OperationContract</c> method.
    /// </para>
    /// <para>
    /// If the string value (as provided by <see cref="QueryStringConverter"/>)
    /// is <c>null</c> or empty or can be successfully parsed into an enum 
    /// value of type <typeparamref name="TEnum"/>, this implementation will
    /// provide an instance of <typeparamref name="TFlags"/>. Thus, there is no
    /// need to check a <typeparamref name="TFlags"/>-typed value for 
    /// <c>null</c> within the implementation of an <c>OperationContract</c>
    /// method.
    /// </para>
    /// </remarks>
    /// <typeparam name="TFlags">
    /// A sub-class of <see cref="Flags{TEnum}"/>. Must have a default c'tor.
    /// </typeparam>
    /// <typeparam name="TEnum">
    /// The enum type. Must be attributed with <see cref="FlagsAttribute"/>.
    /// </typeparam>
    public class FlagsConverter<TFlags, TEnum> : TypeConverter
        where TFlags : Flags<TEnum>, new()
        where TEnum : struct, IConvertible
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                // The following line is what Flags<> and FlagsConverter<,> is
                // all about: Provide the enum's default value (meaning no flag
                // is set) for null and the empty string instead of passing it
                // into Enum.Parse() (which results in an ArgumentException).
                return new TFlags { Value = default(TEnum) };
            }
            // Otherwise, just pass the value on the Enum.Parse(), i.e. don't 
            // add any further changes to WCF's default behavior as implemented
            // by QueryStringConverter.
            return new TFlags { Value = (TEnum)Enum.Parse(typeof(TEnum), (string)value, true) };
        }
    }
    
