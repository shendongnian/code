    /// <summary>
    /// This creates a Xaml markup which can allow converters (which inheirit form this class) to be called directly
    /// without specify a static resource in the xaml markup.
    /// </summary>
    public  class CoverterBase<T> : MarkupExtension where T : class, new()
     {
        private static T _converter = null;
     
        public CoverterBase() { }
     
        /// <summary>Create and return the static implementation of the derived converter for usage in Xaml.</summary>
        /// <returns>The static derived converter</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = (T) Activator.CreateInstance(typeof (T), null));
        }
    }
