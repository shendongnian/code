    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private DynamicStringService DynamicStringService;
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
              Type containerType, Func<object> modelAccessor,
              Type modelType, string propertyName)
        {
            var modelMetadata = base.CreateMetadata(attributes, containerType,
                    modelAccessor, modelType, propertyName);
            List<DisplayAttribute> list = attributes.OfType<DisplayAttribute>().ToList();
            foreach (DisplayAttribute d in list)
            {
                if (!string.IsNullOrEmpty(d.Name))
                {
                    try
                    {
                        DynamicStringService = DependencyResolver.Current.GetService<DynamicStringService>();
                        Language userLanguage = GetCurrentUILanguage();
                        string changingValue = DynamicStringService.ChangeName(d.Name, userLanguage);
                        modelMetadata.DisplayName = changingValue;
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
            }
            return modelMetadata;
        }
    }
