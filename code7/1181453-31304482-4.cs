    [CompilerGenerated]
	private static class <Method3>o__SiteContainer0
	{
		public static CallSite<Func<CallSite, object, IDictionary<string, object>>> <>p__Site1;
	}
    private static void Method3()
    {
    	object expando = new ExpandoObject();
    	if (Program.<Method3>o__SiteContainer0.<>p__Site1 == null)
    	{
    		Program.<Method3>o__SiteContainer0.<>p__Site1 = CallSite<Func<CallSite, object, IDictionary<string, object>>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(IDictionary<string, object>), typeof(Program)));
    	}
    	Program.<Method3>o__SiteContainer0.<>p__Site1.Target(Program.<Method3>o__SiteContainer0.<>p__Site1, expando)["key"] = 1;
    }
