	// Composition Root
	container.Register(typeof(IWindow<>), applicationAssemblies);
	container.Register(typeof(IMessageHandler<>), applicationAssemblies);
	container.RegisterSingleton<IMessageDispatcher>(
		new SimpleInjectorMessageDispatcher(container));
	container.RegisterInitializer<Window>(frm => {
		frm.Unloaded += FormOnUnloaded;
	});
