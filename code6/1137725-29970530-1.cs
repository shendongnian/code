    public static void DoSomething()
    {
        var a = new A(); 
        TheMainObject theMainObject = null; 
        var ctor = typeof (TheMainObject).GetConstructor(new[] {typeof (IA)}); 
        if (ctor != null) {
    	    theMainObject = (TheMainObject) ctor.Invoke(new object[] {a});
        }
    }
