    public static bool Equate(System.Delegate a, System.Delegate b)
    {
    	// ADDED THIS --------------
    	// remove delegate overhead
    	while (a.Target is Delegate)
    		a = a.Target as Delegate;
    	while (b.Target is Delegate)
    		b = b.Target as Delegate;
    
    	// standard equality
    	if (a == b)
    		return true;
    
    	// null
    	if (a == null || b == null)
    		return false;
    
    	// compiled method body
    	if (a.Target != b.Target)
    		return false;
    	byte[] a_body = a.Method.GetMethodBody().GetILAsByteArray();
    	byte[] b_body = b.Method.GetMethodBody().GetILAsByteArray();
    	if (a_body.Length != b_body.Length)
    		return false;
    	for (int i = 0; i < a_body.Length; i++)
    	{
    		if (a_body[i] != b_body[i])
    			return false;
    	}
    	return true;
    }
