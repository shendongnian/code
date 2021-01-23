    public class JsonBodyModelBinder<T> : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext,
            ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(T))
            {
                return false;
            }
            try
            {
                var json = ExtractRequestJson(actionContext);
                bindingContext.Model = DeserializeObjectFromJson(json);
                return true;
            }
            catch (JsonException exception)
            {
                bindingContext.ModelState.AddModelError("JsonDeserializationException", exception);
                return false;
            }
            
            return false;
        }
        private static T DeserializeObjectFromJson(string json)
        {
            var binder = new TypeNameSerializationBinder("");
            var obj = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Binder = binder
            });
            return obj;
        }
        private static string ExtractRequestJson(HttpActionContext actionContext)
        {
            var content = actionContext.Request.Content;
            string json = content.ReadAsStringAsync().Result;
            return json;
        }
    }
