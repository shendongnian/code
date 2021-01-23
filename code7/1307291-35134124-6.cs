    double d1 = 1.1;
	double d2 = 2.2;
	MethodInfo mi = typeof(Double).GetMethod("op_Equality", BindingFlags.Static | BindingFlags.Public );
	
	bool b = (bool)(mi.Invoke(null, new object[] {d1,d2}));
