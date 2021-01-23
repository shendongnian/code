    public void DoThing(Type t)
    {
    	var m = t.GetMethod("Fizz", BindingFlags.Public | BindingFlags.Static);
    	if(m != null)
    		m.Invoke(null, null);
    }
