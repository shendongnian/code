    // make sure there is only 1 instance of _obj shared between all threads
    // one approach to do this would be to use a static object
    private static object _obj = new object();
    public void MsgBox(Int i, Int j)
    {
    	lock(_obj) 
    	{
            MessagBox.Show ("a");
            MessagBox.Show ("b");
    	}
    }
