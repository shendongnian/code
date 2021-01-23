    private static string GetErrorMessage(ModelMetadata metadata)
        {
            string retVal = String.Empty;
            var customTypeDescriptor = new AssociatedMetadataTypeTypeDescriptionProvider(metadata.ContainerType).GetTypeDescriptor(metadata.ContainerType);
            if (customTypeDescriptor != null)
            {
                var descriptor = customTypeDescriptor.GetProperties().Find(metadata.PropertyName, true);
                var req = (new List<Attribute>(descriptor.Attributes.OfType<Attribute>())).OfType<RequiredAttribute>().FirstOrDefault();
                if (req != null)
                    retVal = req.ErrorMessage;
            }
            return retVal;
        }
