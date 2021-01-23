		[CompilerGenerated]
		private sealed class <>c__DisplayClass1_0
		{
			public int myLocalVar;
		}
		public static string Test()
		{
			Class1.<>c__DisplayClass1_0 <>c__DisplayClass1_ = new Class1.<>c__DisplayClass1_0();
			<>c__DisplayClass1_.myLocalVar = 2;
			int num = 2;
			num++;
			return Class1.GetMemberName<int>(
				Expression.Lambda<Func<int>>(
					Expression.MakeMemberAccess(
						Expression.Constant(<>c__DisplayClass1_, typeof(Class1.<>c__DisplayClass1_0)),
						typeof(Class1.<>c__DisplayClass1_0).GetMember("myLocalVar")
					)
				)
			);
		}
    
