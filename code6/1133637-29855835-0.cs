        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MetadataConfig)element).Name;
        }
        public void Remove(MetadataConfig element)
        {
            BaseRemove(element.Name);
        }
