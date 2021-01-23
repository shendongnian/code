    protected override JsonContract CreateContract(Type objectType)
    {
       if (TypeDescriptor.GetAttributes(objectType).Contains(new TypeConverterAttribute(typeof(ExpandableObjectConverter))))
       {
           return this.CreateObjectContract(objectType);
       }
       return base.CreateContract(objectType);
    }
