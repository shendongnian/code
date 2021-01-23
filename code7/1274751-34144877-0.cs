    class MyGenericClass
	{
        public void SetMethod<T>(Func<T, string, string, int> method)
			where T : IMyType
        {
        }
    }
    MyGenericClass myGenericClass = new MyGenericClass();
    myGenericClass.SetMethod<IMyType>((t, s1, s2) => t.MethodOfMyType(s1, s2));
