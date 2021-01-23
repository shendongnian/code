        public class Model
        {
            public IDictionary<string, object> Entries { get; set; }
        }
        
        public class CustomModelBinder : IModelBinder
        {
    
            public bool CanBind(Type modelType)
            {
                return modelType == typeof(Model);
            }
    
            public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList)
            {
                using (var sr = new StreamReader(context.Request.Body))
                {
                    return (new JavaScriptSerializer() { RetainCasing = true }).Deserialize<Model>(sr.ReadToEnd());
                }
            }
        }
