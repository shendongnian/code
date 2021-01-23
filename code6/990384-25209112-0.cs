    public class AlphabetElement : ConfigurationElement
    {
        private static ConfigurationPropertyCollection _properties;
        private static ConfigurationProperty _a;
        [ConfigurationProperty("A")]
        public Letter A
        {
            get { return (Letter)base[_a]; }
        }
        private static ConfigurationProperty _b;
        [ConfigurationProperty("B")]
        public Letter B
        {
            get { return (Letter)base[_a]; }
        }
        private static ConfigurationProperty _c;
        [ConfigurationProperty("C")]
        public Letter C
        {
            get { return (Letter)base[_c]; }
        }
        static AlphabetElement()
        {
            // Initialize the ConfigurationProperty settings here...
        }
        public static void Validate(object value)
        {
            AlphabetElement element = value as AlphabetElement;
            if (element == null)
                throw new ArgumentException(
                    "The method was called on an invalid object.", "value");
            if (A == null && (B == null || C == null))
                throw new ArgumentException(
                    "Big A, little a, bouncing beh... " +
                    "The system might have got you but it won't get me.");
        }
    }
    public class BestBefore : ConfigurationSection
    {
        private static ConfigurationPropertyCollection _properties;
        private static ConfigurationProperty _alphabetElement;
        [ConfigurationProperty("alphabet", IsRequired = true)]
        public AlphabetElement Alphabet
        {
            get { return (AlphabetElement)base[_alphabetElement]; }
        }
        static BestBefore()
        {
            _properties = new ConfigurationPropertyCollection();
            _alphabetElement = new ConfigurationProperty(
                "alphabet",
                typeof(AlphabetElement),
                null,
                null,
                new CallbackValidator(
                    typeof(AlphabetElement),
                    new ValidatorCallback(AlphabetElement.Validate)),
                ConfigurationPropertyOptions.IsRequired);
            _properties.Add(_alphabetElement);
        }
    }
