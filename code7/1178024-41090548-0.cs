        [ConfigurationProperty("type")]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type Type
        {
            get
            {
                return (System.Type)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }
