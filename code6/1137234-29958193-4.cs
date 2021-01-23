	private void Main()
	{
		object obj = (object)this;
		if (SiteContainer.Site == null)
			SiteContainer.Site = CallSite<Action<CallSite, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "DoSomething", (IEnumerable<Type>)null, typeof(UserQuery), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
			}));
		SiteContainer.Site.Target((CallSite)SiteContainer.Site, obj);
	}
	
	private void DoSomething()
	{
		Console.WriteLine("Foo");
	}
	
	[CompilerGenerated]
	private static class SiteContainer
	{
		public static CallSite<Action<CallSite, object>> Site;
	}
