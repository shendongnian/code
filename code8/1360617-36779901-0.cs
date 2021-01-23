	[AttributeUsage(AttributeTargets.Method)]
	class DynFuncMemberAttribute : Attribute
	{
	}
	class DynObj : DynamicObject
	{
		Dictionary<string, MethodInfo> cache;
		GetMemberBinder saveOperation;
		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			saveOperation = binder;
			result = this;
			return true;
		}
		public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
		{
			if (cache == null)
				cache = BuildCache();
			MethodInfo mi;
			if (cache.TryGetValue(saveOperation.Name, out mi))
			{
				result = mi.Invoke(null, args);
				return true;
			}
			result = null;
			return false;
		}
		private Dictionary<string, MethodInfo> BuildCache()
		{
			return Assembly.GetEntryAssembly()
				.GetTypes()
				.SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Static))
				.Where(mi => mi.GetCustomAttribute<DynFuncMemberAttribute>() != null)
				.ToDictionary(mi => mi.Name);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			dynamic d1 = new DynObj();
			d1.func1(3, 6);
			d1.func2(3, 6);
		}
	}
	class Test1
	{
		[DynFuncMember]
		public static void func1(int a, int b)
		{
			Console.WriteLine("func1");
		}
	}
	class Test2
	{
		[DynFuncMember]
		public static void func2(int a, int b)
		{
			Console.WriteLine("func2");
		}
	}
