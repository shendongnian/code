    class MyConfigSection : ConfigurationSection
    {
        [ConfigurationProperty(nameof(SomeProperty))]
        public int SomeProperty
        {
            get { return ((int)(base[nameof(SomeProperty)])); }
            set { base[nameof(SomeProperty)] = value; }
        }
    }
