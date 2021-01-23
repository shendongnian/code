    var c = new ClassFromMyLibrary1();
    
    var v1 = c.MethodFromMyLibrary1("test1", ActionToProcessNewValue).Result;
    
    Label2.Content = v1; // updating GUI...
