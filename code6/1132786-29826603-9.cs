    // assuming the method we are calling is defined like this:
    // public String SomeFunction(string string1, String string2, List<String> ra)  
    
    List<string> valueToPassOn;
    if (_ra.ContainsKey(lc.Lc))
    {
	     valueToPassOn = _ra[lc.Lc]
	}
	else
	{
	     valueToPassOn = new List<string>(); 
	}
	
    string text = tooltip.SomeFunction(something1, something2, valueToPassOn); 
