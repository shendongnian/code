    public static class TestClass
    {
	  public static int Value { get; set; }
	  public static string ValueString
	  {
		get { return TestClass.Value.ToString(); }
	  }
    }
