    var preprocessors = from t in Assembly.GetExecutingAssembly().GetTypes()
                                where t.GetInterfaces().Contains(typeof(Preprocessing))
                                select Activator.CreateInstance(t, originalData) as Preprocessing;  // Create instance of class with originalData as parameter
    
    // Obtain a list of all types in the assembly (will be instantiated in the foreach loop)
    var similarities = Assembly.GetExecutingAssembly().GetTypes();
