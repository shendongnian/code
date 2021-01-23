    public class CustomForeignKeyConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Column(instance.Class.Name);
        }
    }
