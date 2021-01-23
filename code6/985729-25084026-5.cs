	[TestMethod]
	public void CanResolveMultipeDefaultMappingsUsingResolveAll()
	{
		var container = new UnityContainer().AddNewExtension<Remember>();
		container.RegisterType<IFoo, One>();
		container.RegisterType<IFoo, Two>();
		container.RegisterType<IFoo, Three>();
		IFoo[] foos = container.ResolveAll<IFoo>().OrderBy(f => f.GetType().Name).ToArray();
		Assert.AreEqual(3, foos.Length);
		Assert.IsInstanceOfType(foos[0], typeof(One));
		Assert.IsInstanceOfType(foos[1], typeof(Three));
		Assert.IsInstanceOfType(foos[2], typeof(Two));
	}
