    public class A : BaseClass
    {
        public override string IAM => "I AM TYPE A";
    }
    public class AInterface : ITestInterface<A>
    {
        public A GetSomething()
        {
            return new A();
        }
    }
    public class B : BaseClass
    {
        public override string IAM => "I AM TYPE B";
    }
    public class BInterface : ITestInterface<B>
    {
        public B GetSomething()
        {
            return new B();
        }
    }
