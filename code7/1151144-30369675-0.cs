    using System;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    
    namespace MyProject.Whatever
    {
        public class CustomDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
        {
            protected override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, PropertyDescriptor propertyDescriptor)
            {
                ModelMetadata metadata = base.GetMetadataForProperty(modelAccessor, containerType, propertyDescriptor);
                if (metadata.DisplayName == null)
                {
                    metadata.DisplayName = SplitCamelCase(metadata.GetDisplayName());
                }
                return metadata;
            }
    
            private string SplitCamelCase(string str)
            {
                return Regex.Replace(
                    Regex.Replace(
                        str,
                        @"(\P{Ll})(\P{Ll}\p{Ll})",
                        "$1 $2"
                    ),
                    @"(\p{Ll})(\P{Ll})",
                    "$1 $2"
                );
            }
        }
    }
