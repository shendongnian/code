    public class CustomModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var body = actionContext.Request.Content.ReadAsStringAsync().Result;
            body = body.Replace("json=", "");
            var json = HttpUtility.UrlDecode(body);
            bindingContext.Model = JsonConvert.DeserializeObject<CallDetails>(json);
            return true;
        }
    }
