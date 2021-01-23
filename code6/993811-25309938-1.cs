    void KernelComponentModelCreated(ComponentModel model)
	{
		if (typeof(ICanDoMagic).IsAssignableFrom(model.Implementation))
		{
			model.AddService(typeof(ICanDoMagic));
		}
	}
