    class AnimalSpeciesConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            Animal test = context.Instance as Animal;
    
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
            string[] names = Enum.GetNames(typeof(AnimalSpecies))
                               .Where(x => !x.StartsWith("Rob")).ToArray();
    
            return new StandardValuesCollection(names);
        }
    }
