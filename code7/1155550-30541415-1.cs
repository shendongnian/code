    public class StringDictionaryBinder : IModelBinder
    {
        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList)
        {
            var result = (instance as Dictionary<string, string>) ?? new Dictionary<string, string>();
            IDictionary<string, object> formData = (DynamicDictionary) context.Request.Form;
            foreach (var item in formData)
            {
                var itemValue = Convert.ChangeType(item.Value, typeof (string)) as string;
                result.Add(item.Key, itemValue);
            }
            return result;
        }
        public bool CanBind(Type modelType)
        {
            // http://stackoverflow.com/a/16956978/39605
            if (modelType.IsGenericType && modelType.GetGenericTypeDefinition() == typeof (Dictionary<,>))
            {
                if (modelType.GetGenericArguments()[0] == typeof (string) &&
                    modelType.GetGenericArguments()[1] == typeof (string))
                {
                    return true;
                }
            }
            return false;
        }
    }
