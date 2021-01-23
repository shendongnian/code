    class AnimalSpeciesConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            IValuesProvider test = context.Instance as IValuesProvider;
            if (test != null)
                return true;
            else
                return base.GetStandardValuesSupported();
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
        
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            IValuesProvider item = context.Instance as IValuesProvider;
            return new StandardValuesCollection(item.GetValues());
        }
    }
