    try
    {
        var inspector = Inspectors.SingleOrDefault();
        if(inspector != null && inspector.InspectorPass == Pass)
        {}
    }
    catch(){}
