	private IDependency _someDependency;
	
	public HomeController(IDependency someDependency)
	{
		_someDependency = someDependency;
	}
	public ActionResult MyMethod()
	{
		var title = "";
		var version = "";
		IEnumerable<Attribute> attributes = GetCustomAttributes(typeof(AssemblyVersionAttribute)).ToList();
		AssemblyVersionAttribute verAttr = attributes.OfType<AssemblyVersionAttribute>().FirstOrDefault();
		if (verAttr != null) version = verAttr.Version;
		attributes = GetCustomAttributes(typeof(AssemblyTitleAttribute)).ToList();
		AssemblyTitleAttribute titleAttr = attributes.OfType<AssemblyTitleAttribute>().FirstOrDefault();
		if (titleAttr != null) title = titleAttr.Title;
		return PartialView("_Build", title + version);
	}
	public virtual IEnumerable<Attribute> GetCustomAttributes(Type attributeType)
	{
		var asm = Assembly.GetExecutingAssembly();
		var attrs = asm.GetCustomAttributes(attributeType);
		return attrs;
	} 
