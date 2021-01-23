    // StringCollection only implements IList, so cast, then convert
    var someStrings = Properties.Settings.Default.SomeStrings.Cast<string>().ToArray();
    container.Register(Component.For<IMyComponent>()
								.ImplementedBy<MyComponent>()
								.LifestyleTransient()
								.DependsOn(Dependency.OnValue<IList<string>>(someStrings)));
