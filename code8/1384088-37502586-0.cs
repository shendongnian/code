	private static ConcurrentDictionary<string, Type> _contentTypes = new ConcurrentDictionary<string, Type>();
	public IHttpHandler GetHttpHandler(RequestContext requestContext)
	{
		// Retrieve the page ID from the route data
		var id = GetContentIdFromRouteData(requestContext);
		// Retrieve the content identified by the specified ID
		var contentRepository = new ContentRepository();
		var content = contentRepository.Get(id);
		if (content == null)
			throw new ContentNotFoundException(id);
        
		// Retrieve all content type values and pass them on the the method for index pages
		var action = requestContext.RouteData.GetRequiredString("action");
		if (action == "Index")
		{
			var data = CreateContentType(requestContext, content);
			requestContext.RouteData.Values.Add("data", data);
		}
		var values = requestContext.RouteData.Values;
		values.Add("name", content.Name);
		values.Add("controllerId", id);
		values.Add("controller", content.ControllerName);
		return new MvcHandler(requestContext);
	}
	private static int GetContentIdFromRouteData(RequestContext context)
	{
		var idString = context.RouteData.GetRequiredString("id");
		int id;
		if (!int.TryParse(idString, out id))
			throw new ArgumentException("Content can't be loaded due to an invalid route parameter.", "id");
		return id;
	}
	private static ContentType CreateContentType(RequestContext context, Content content)
	{
		Type type;
		if (!_contentTypes.ContainsKey(content.ControllerName) || 
			!_contentTypes.TryGetValue(content.ControllerName, out type))
		{
			var factory = ControllerBuilder.Current.GetControllerFactory();
			var controller = (IContentController)factory.CreateController(context, content.ControllerName);
			if (controller == null)
				throw new ControllerNotFoundException(content.ControllerName);
			type = controller.ContentType;
			_contentTypes.TryAdd(content.ControllerName, type);                
		}
		ContentType data = null;
		if (type != null)
		{
			data = BusinessHost.Resolve<ContentType>(type);
			data.Values = content.Parameters.ToDictionary(p => p.Name, p => p.Value);
		}
		return data;
	}
