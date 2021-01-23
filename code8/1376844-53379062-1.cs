    public class ResourceRecordModelBinder<T> : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(T))
                return false;
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
        }
        private static T DeserializeObjectFromJson(string json)
        {
            // This is the main part of the conversion
            var obj = JsonConvert.DeserializeObject<T>(json, new ResourceRecordConverter());
            return obj;
        }
        private string ExtractRequestJson(HttpActionContext actionContext)
        {
            var content = actionContext.Request.Content;
            string json = content.ReadAsStringAsync().Result;
            return json;
        }
    }
