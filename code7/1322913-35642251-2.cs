    IUnityContainer container = new UnityContainer();
    Toggle toggle = new Toggle();
    toggle.SetToggleOn();
    container.AddExtension(new ToggleExtension(toggle));
    Interface<X> x = container.Resolve<Interface<X>>();
    Debug.Assert(x.GetType() == typeof(Class1<X>));
    toggle.SetToggleOff();
    x = container.Resolve<Interface<X>>();
    Debug.Assert(x.GetType() == typeof(Class2<X>));
