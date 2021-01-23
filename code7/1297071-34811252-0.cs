    public class UpperCaseDiscriminatorConvention : IStoreModelConvention<EdmProperty>
    {
        public void Apply(EdmProperty property, DbModel model)
        {
            if (property.Name == "Discriminator")
            {
                property.Name = "DISCRIMINATOR";
            }
        }
    }
