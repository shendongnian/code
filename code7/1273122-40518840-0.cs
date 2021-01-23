    public static class NewtonsoftJsonExtensions
    {
        public static ActionResult ToJsonResult(this object obj)
        {
            var content = new ContentResult();
            content.Content = JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            content.ContentType = "application/json";
            return content;
        }
    }
