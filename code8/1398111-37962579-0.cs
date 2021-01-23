		var container = new Container();
		
		container.RegisterMany<Action1>();                 
        container.RegisterMany<Command1>();
		
		var parsersList = container.Resolve<IList<IParser>>();
		
		// works fine
		container.Resolve<IAction>();
		
		// works fine
		container.Resolve<ICommand>();
		
		// Throws because IParser is registered multiple times (as Action and as Command),
		// and container is unable to select one. This is precisely what exception is saying.
		//container.Resolve<IParser>();
