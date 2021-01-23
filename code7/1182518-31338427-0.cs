    List<ConstructorInfo> constructors = new List<ConstructorInfo>();
    Type[] types = SampleAssembly.GetTypes();
    foreach (Type type in types)
    {
        constructors.AddRange(type.GetConstructors());
    }
    foreach (ConstructorInfo items in constructors)
    {
        ParameterInfo[] Params = items.GetParameters();
        foreach (ParameterInfo itema in Params)
        {
            System.Windows.Forms.MessageBox.Show(itema.ParameterType + " " + itema.Name);
        }
    }
