    /// <summary>
    /// Markup extension providing the Tx.UT method functionality.
    /// </summary>
    public class UATExtension : TExtension
    {
        #region Constructors
        /// <summary>
        /// Initialises a new instance of the UATExtension class.
        /// </summary>
        public UATExtension()
            : base()
        {
        }
        /// <summary>
        /// Initialises a new instance of the UATExtension class.
        /// </summary>
        /// <param name="key">Text key to translate.</param>
        public UATExtension(string key)
            : base(key)
        {
        }
        /// <summary>
        /// Initialises a new instance of the UATExtension class.
        /// </summary>
        /// <param name="key">Text key to translate.</param>
        /// <param name="count">Count value to consider when selecting the text value.</param>
        public UATExtension(string key, int count)
            : base(key, count)
        {
        }
        /// <summary>
        /// Initialises a new instance of the UATExtension class.
        /// </summary>
        /// <param name="key">Text key to translate.</param>
        /// <param name="countBinding">Binding that provides the count value to consider when selecting the text value.</param>
        public UATExtension(string key, Binding countBinding)
            : base(key, countBinding)
        {
        }
        #endregion Constructors
        #region Converter action
        /// <summary>
        /// Provides the T method in specialised classes.
        /// </summary>
        /// <returns></returns>
        protected override Func<string, int, string> GetTFunc()
        {
            return TTx.UAT;
        }
        #endregion Converter action
    }
