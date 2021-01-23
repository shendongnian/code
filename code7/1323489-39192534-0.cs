    using System;
    ...
    try {
        var getExecutingAssembly = typeof(Assembly).GetRuntimeMethods()
                                    .Where(m => m.Name.Equals("GetExecutingAssembly"))
                                    .FirstOrDefault();
        var assemblies = getExecutingAssembly.Invoke(null, null);
    } catch(Exception exc){
       ... try something else
    } finally{
       ... time for some alternative 
    }
