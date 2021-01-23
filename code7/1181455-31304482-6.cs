    [CompilerGenerated]
    private static class <Method2>o__SiteContainer0
    {
        public static CallSite<Func<CallSite, object, string, int, object>> <>p__Site1;
    }
    private static void Main(string[] args)
    {
        Program.Method1();
        Program.Method2();
    }
    private static void Method1()
    {
        IDictionary<string, object> expando = new ExpandoObject();
        expando["key"] = 1;
    }
    private static void Method2()
    {
        object expando = new ExpandoObject();
        if (Program.<Method2>o__SiteContainer0.<>p__Site1 == null)
        {
        	Program.<Method2>o__SiteContainer0.<>p__Site1 = CallSite<Func<CallSite, object, string, int, object>>.Create(Binder.SetIndex(CSharpBinderFlags.None, typeof(Program), new CSharpArgumentInfo[]
        	{
        		CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
        		CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
        		CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
        	}));
        }
        Program.<Method2>o__SiteContainer0.<>p__Site1.Target(Program.<Method2>o__SiteContainer0.<>p__Site1, expando, "key", 1);
    }
