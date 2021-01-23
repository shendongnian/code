    private readonly IActionContextAccessor actionContextAccessor
	public FooController(IActionContextAccessor actionContextAccessor)
	{
		this.actionContextAccessor = actionContextAccessor;
	}
