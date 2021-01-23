    class Test
    {
        static void Main()
        {
		    CallWithNullThis("Foo");
		    CallWithNullThis("Bar");
        }
        static void CallWithNullThis(string methodName)
	    {
	        var mi = typeof(Test).GetMethod(methodName);
            // make Test the owner type to avoid VerificationException
            var dm = new DynamicMethod("$", typeof(void), Type.EmptyTypes, typeof(Test));
            var il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldnull);
            il.Emit(OpCodes.Call, mi);
            il.Emit(OpCodes.Ret);
            var action = (Action)dm.CreateDelegate(typeof(Action));
            action();
	    }
        public void Foo()
        {
            Console.WriteLine(this == null ? "Weird" : "Normal");
        }
        public virtual void Bar()
        {
            Console.WriteLine(this == null ? "Weird" : "Normal");
        }
    }
