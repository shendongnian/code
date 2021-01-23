    /// <summary>
    /// Specifies the database table that a class is mapped to with pluralization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "We want users to be able to extend this class")]
    public class PluralizedTableAttribute : TableAttribute
    {
        private const string _englishCultureName = "en-us";
        /// <summary>
        /// Initializes a new instance of the <see cref="PluralizedTableAttribute"/> class.
        /// </summary>
        /// <param name="name">The table name.</param>
        public PluralizedTableAttribute(string name)
            :base(PluralizationService.CreateService(CultureInfo.GetCultureInfo(_englishCultureName)).Pluralize(name)) // pluralization only suported in English.
        {
        }
    }
