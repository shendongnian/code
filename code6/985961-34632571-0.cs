        public class MyRequiredAttributeAdapter : DataAnnotationsModelValidator<MyRequiredAttribute>
        {
            public MyRequiredAttributeAdapter(ModelMetadata metadata, ControllerContext context, MyRequiredAttribute attribute)
                : base(metadata, context, attribute)
            {
                if (string.IsNullOrWhiteSpace(attribute.ErrorMessage)
                    && string.IsNullOrWhiteSpace(attribute.ErrorMessageResourceName)
                    && attribute.ErrorMessageResourceType == null)
                {
                    attribute.ErrorMessageResourceType = typeof(Resources.Validation.Messages);
                    attribute.ErrorMessageResourceName = "PropertyValueRequired";
                }
            }
        }
