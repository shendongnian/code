	public void MyUnitTest()
	{
		IUnityContainer myContainer = new UnityContainer();
		myContainer.RegisterType<IInterface, YourInstance>();
		MyClass classUnderTest = new MyClass(myContainer);
		classUnderTest.DoWork();
		
		Assert...
	}
