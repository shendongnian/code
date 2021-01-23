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
            return modelType.IsGenericType && modelType.GetGenericTypeDefinition() == typeof (Dictionary<,>);
        }
    }
