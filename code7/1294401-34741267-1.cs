    void Main()
    {
    	IUnityContainer container = new UnityContainer();
    	
        // This mapping can be done trivially in XML configuration.
        // Left as an exercise for the reader :)
    	container.RegisterType<IInterfaceFactory, StandardInterfaceFactory>();
    	
    	IInterfaceFactory factory = container.Resolve<IInterfaceFactory>();
    	
    	IInterface myInterface = factory.CreateInterface();
    	
    	myInterface.SomeMethod1();
    }
    
