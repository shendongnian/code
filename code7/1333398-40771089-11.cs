    public class Trigger<T> : Aspect
    {
        static public event EventArgs MethodCalled;
        static private Trigger<T> m_Singleton = new Trigger<T>();
        //Auto weaving aspect
        static Trigger()
        {
            Aspect.Weave<Trigger<T>>(method => method.ReflectedType == typeof(T));
        }
        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            //define an advice to trigger only when method execution not failed
            yield return Advice.Basic.After.Returning(() => 
            {
                if (MethodCalled != null)
                {
                    MethodCalled(this, null);
                }
            });
        }
    }
    public class A
    {
        public void Test()
        {
        }
    }
    int main(string[] args)
    {
        Trigger<A>.MethodCalled += ...
        new A().Test();
    }
