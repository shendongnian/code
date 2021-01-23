    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
		if (controllerContext.HttpContext.Request.ContentType.ToLowerInvariant().StartsWith("my special content type"))
		{
			var body = GetBody(controllerContext.HttpContext.Request);
			var model = MyCustomConverter.Deserialize(body, bindingContext.ModelType);
			return model;
		}
    }
	private static string GetBody(HttpRequestBase request)
	{
		var inputStream = request.InputStream;
		inputStream.Position = 0;
		using (var reader = new StreamReader(inputStream))
		{
			var body = reader.ReadToEnd();
			return body;
		}
	}
