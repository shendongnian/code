    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SanitizePropertyAttribute : Attribute
    {
    }
    public class SanitizeTextInputFormatter: Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter
    {
        private List<String> ExcludeTypes = new List<string>()
        {
            "System.DateTime",
            "System.Int32",
            "System.Int64",
            "System.Boolean",
            "System.Char",
            "System.Object"
        };
        private string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                // [<>/] or @"[^\w\.@-]"
                return Regex.Replace(strIn, @"[<>/]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
        public SanitizeTextInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        private bool ValidateSanitizeProperty(Type type, PropertyInfo PropertyInfo, List<PropertyInfo> orgTypes)
        {
            var listedProperty = orgTypes.Where(_ => _ == PropertyInfo).FirstOrDefault();
            if (PropertyInfo != null && listedProperty == null) orgTypes.Add(PropertyInfo);
            if (listedProperty != null) return false;
            if (type.FullName == "System.String" && PropertyInfo != null)
            {
                var sanitizePropertyAttribute = PropertyInfo.GetCustomAttribute<SanitizePropertyAttribute>();
                //var sanitizeClassAttribute = PropertyInfo.CustomAttributes.Where(e => e.AttributeType == typeof(SanitizePropertyAttribute)).FirstOrDefault();
                return sanitizePropertyAttribute != null;
            }
            var typeProperties = type.GetProperties().Where(_ => _.PropertyType.IsAnsiClass == true && !ExcludeTypes.Contains(_.PropertyType.FullName)).ToList();
            var doSanitizeProperty = false;
            typeProperties.ForEach(typeProperty =>
            {
                if (doSanitizeProperty == false)
                    doSanitizeProperty = ValidateSanitizeProperty(typeProperty.PropertyType, typeProperty, orgTypes);
            });
            return doSanitizeProperty;
          
        }
        protected override bool CanReadType(Type type)
        {
            var result = ValidateSanitizeProperty(type, null, new List<PropertyInfo>());
            return result;
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
                            propertyInfo.SetValue(obj, CleanInput(raw));
                            //propertyInfo.SetValue(obj, AntiXssEncoder.HtmlEncode(raw, true));
                            //propertyInfo.SetValue(obj, AntiXssEncoder.UrlEncode(raw));
                        }
                    }
                }
            }
            modelType.GetProperties().ToList().Where(_ => _.PropertyType.IsAnsiClass == true && !ExcludeTypes.Contains(_.PropertyType.FullName)).ToList().ForEach(property =>
            {
                try
                {
                    var nObj = property.GetValue(obj);
                    if (nObj != null)
                    {
                        var sObj = SanitizeObject(nObj, property.PropertyType);
                        property.SetValue(obj, sObj);
                    }
                }
                catch(Exception ex)
                {   
                }
            });
            return obj;
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
                try
                {
                    var sbj = SanitizeObject(nObj, modelType);
                    return await InputFormatterResult.SuccessAsync(sbj);
                }catch (Exception ex)
                {
                    return await InputFormatterResult.FailureAsync();
                }
            }
        }
    }
