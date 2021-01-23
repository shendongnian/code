    NewSettings ns = new NewSettings();
    var obj = (object)ns;
    PropertyInfo pi = ns.GetType().GetProperty("a");
            
    pi.SetValue(obj, "123");
    ns = (NewSettings)obj;
