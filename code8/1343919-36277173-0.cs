	// note: ICommandMenuItem naming convention for [Foo]Command: [Foo]CommandMenuItem
	var item = types.SingleOrDefault(type => type.Name == commandName + "CommandMenuItem");
	if (item != null)
	{
		_kernel.Bind<ICommand>().To(command)
			   .WhenInjectedExactlyIntoAnyOf(item, typeof(ConfigurationLoader))
			   .InSingletonScope();
	}
