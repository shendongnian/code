	[ContractAnnotation("condition:false=>halt")]
	public static void Assert(bool condition)
	{
		Trace.Assert(condition);
	}
