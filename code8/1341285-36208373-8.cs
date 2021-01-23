	public enum Test
	{
		[Description("A test enum value for 'Foo'")]
		Foo,
		[Description("A test enum value for 'Bar'")]
		Bar
	}
    typeof(Test).ToDictionary<Test>()
