    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SanitizePropertyAttribute : Attribute
    {
    }
    public class SanitizeTextInputFormatter: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter
    { 
        public SanitizeTextInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        private bool ValidateSanitizeProperty(Type type)
        {
            //var sanitizeClassAttribute = type.CustomAttributes.Where(e => e.AttributeType == typeof(SanitizeClassAttribute)).FirstOrDefault();
            //if (sanitizeClassAttribute != null) return true;
            List<PropertyInfo> propertiesFlaggedForSanitization = type.GetProperties().Where(e => e.GetCustomAttribute<SanitizePropertyAttribute>() != null).ToList();
            if (propertiesFlaggedForSanitization.Count > 0) return true;
            bool tmp = false;
            type.GetProperties().ToList().Where(_ => _.PropertyType.IsClass == true).ToList().ForEach(property =>
            {
                if (tmp == false && ValidateSanitizeProperty(property.PropertyType) == true)
                    tmp = true;
            });
            return tmp;
        }
        private object SanitizeObject(object obj, Type modelType)
        {
            if (obj != null)
            {
                List<PropertyInfo> propertiesFlaggedForSanitization = modelType.GetProperties().Where(e => e.GetCustomAttribute<SanitizePropertyAttribute>() != null).ToList();
                if (propertiesFlaggedForSanitization.Any())
                {
                    foreach (var propertyInfo in propertiesFlaggedForSanitization)
                    {
                        var raw = (string)propertyInfo.GetValue(obj);
                        if (!string.IsNullOrEmpty(raw))
                        {
                            propertyInfo.SetValue(obj, AntiXssEncoder.HtmlEncode(raw, true));
                        }
                    }
                }
            }
            modelType.GetProperties().ToList().Where(_ => _.PropertyType.IsClass == true).ToList().ForEach(property =>
            {
                var nObj = property.GetValue(obj);
                if (nObj != null)
                {                    
                    var sObj = SanitizeObject(nObj, property.PropertyType);
                    property.SetValue(obj, sObj);
                }
            });
            return obj;
        }
        protected override bool CanReadType(Type type)
        {
            return ValidateSanitizeProperty(type);
        }
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }
            using (var streamReader = context.ReaderFactory(context.HttpContext.Request.Body, encoding))
            {
                string jsonData = await streamReader.ReadToEndAsync();
                var nObj = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData, context.ModelType);
                var modelType = context.ModelType;
                var sbj = SanitizeObject(nObj, modelType);
                return await InputFormatterResult.SuccessAsync(sbj);           
            }
        }
    }
