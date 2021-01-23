    //Get the RealProxy of the element
    var elementProxy = System.Runtime.Remoting.RemotingServices.GetRealProxy(element);
    
    //Get the Bys from the RealProxy:    
    var bysFromElement = (IReadOnlyList<object>)elementProxy.GetType().GetProperty("Bys", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public)?.GetValue(elementProxy);
    
    //Convert bysFromElement to a list of strings for manipulation, or convert into a list of By objects, i.e.:       
    var bys = new List<string>();
    if (bysFromElement != null)
    {
        bys.AddRange(bys.Select(@by => @by.ToString()));
    }
