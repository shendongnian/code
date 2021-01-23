    class MyAttr : Attribute { }
    class Program
    {
        [Pure]
        [ResourceExposure(ResourceScope.AppDomain)]
        [MethodImpl]
        [MyAttr]
        public void Foo() { }
    }
