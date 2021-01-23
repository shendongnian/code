    /// <summary>
    /// Safely reset the keyboard bindings on this Command to the provided values
    /// </summary>
    public static void SafeSetBindings(this DteCommand command, IEnumerable<string> commandBindings)
    {
    	try
    	{
    		var bindings = commandBindings.Cast<object>().ToArray();
    		command.Bindings = bindings;
    
    		// There are certain commands in Visual Studio which simply don't want to have their
    		// keyboard bindings removed.  The only way to get them to relinquish control is to
    		// ask them to remove the bindings twice.  
    		//
    		// One example of this is SolutionExplorer.OpenFilesFilter.  It has bindings for both
    		// "Ctrl-[, O" and "Ctrl-[, Ctrl-O".  Asking it to remove all bindings will remove one
    		// but not both (at least until you restart Visual Studio, then both will be gone).  If
    		// we ask it to remove bindings twice though then it will behave as expected.  
    		if (bindings.Length == 0 && command.GetBindings().Count() != 0)
    		{
    			command.Bindings = bindings;
    		}
    	}
    	catch (Exception)
    	{
    		// Several implementations, Transact SQL in particular, return E_FAIL for this
    		// operation.  Simply ignore the failure and continue
    	}
