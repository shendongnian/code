    /// <summary>
    /// Set a default value defined on the sql server
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class SqlDefaultValueAttribute : Attribute
    {
        /// <summary>
        /// Default value to apply
        /// </summary>
        public string DefaultValue { get; set; }
    
        /// <summary>
        /// Set a default value defined on the sql server
        /// </summary>
        /// <param name="value">Default value to apply</param>
        public SqlDefaultValueAttribute(string value)
        {
            DefaultValue = value;
        }
    }
    
    /// <summary>
    /// Set the decimal precision of a decimal sql data type
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DecimalPrecisionAttribute : Attribute
    {
        /// <summary>
        /// Specify the precision - the number of digits both left and right of the decimal
        /// </summary>
        public int Precision { get; set; }
    
        /// <summary>
        /// Specify the scale - the number of digits to the right of the decimal
        /// </summary>
        public int Scale { get; set; }
    
        /// <summary>
        /// Set the decimal precision of a decimal sql data type
        /// </summary>
        /// <param name="precision">Specify the precision - the number of digits both left and right of the decimal</param>
        /// <param name="scale">Specify the scale - the number of digits to the right of the decimal</param>
        public DecimalPrecisionAttribute(int precision, int scale)
        {
            Precision = precision;
            Scale = scale;
        }
    
        public DecimalPrecisionAttribute(int[] values)
        {
            Precision = values[0];
            Scale = values[1];
        }
    }
