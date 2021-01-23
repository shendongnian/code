     var obj = new Test();
     var type = obj.GetType();
     var m = type.GetMethod("GetData");
    
     var pars = new object[] { null };
     m.Invoke(obj, pars);
