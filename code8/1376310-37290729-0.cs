    class BaseClass
    {
        public override bool Equals(object other)
        {
            Console.WriteLine("BaseClass");
            return false;
        }
    }
    class DerivedClass
    {
        public bool Equals(DerivedClass other)
        {
            Console.WriteLine("DerivedClass Equals");
            return true;
        }
        public override bool Equals(object other)
        {
            Console.WriteLine("DerivedClass Object Equals");
            return true;
        }
    }
    static class MyComparerThing<TParentType>
    {
        public static bool Equals(TParentType left, TParentType right) => MyComparerThing<TParentType, TParentType, object>.Equals(left, right);
    }
    static class MyComparerThing<TParentType, TOnType>
    {
        public static bool Equals(TOnType left, TOnType right) => MyComparerThing<TParentType, TOnType, object>.Equals(left, right);
    }
    static class MyComparerThing<TParentType, TOnType, TCompareType>
    {
        static Func<TOnType, TOnType, bool> baseEquals;
        static MyComparerThing()
        {
            DynamicMethod dm = new DynamicMethod("BaseFoo", typeof(bool), new Type[] { typeof(TOnType), typeof(TOnType) }, typeof(TOnType));
            ILGenerator gen = dm.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldarg_1);
            var method = typeof(TParentType).GetMethod("Equals", new[] { typeof(TCompareType) });
            gen.Emit(OpCodes.Call, method);
            gen.Emit(OpCodes.Ret);
            baseEquals = (Func<TOnType, TOnType, bool>)dm.CreateDelegate(typeof(Func<TOnType, TOnType, bool>));
        }
        public static bool Equals(TOnType left, TOnType right) => baseEquals(left, right);
    }
