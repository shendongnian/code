        [ConfigurationProperty("contacts")]
        [TypeConverter(typeof(StringSplitConverter))]
        public IEnumerable<string> Contacts
        {
            get
            {
                return (IEnumerable<string>)base["contacts"];
            }
        }
