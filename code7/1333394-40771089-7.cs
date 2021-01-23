    public class Trigger<T> : Aspect
    {
        static public event EventArgs MethodCalled;
        static private Trigger<T> m_Singleton = new Trigger<T>();
        private Trigger()
        {
            // automatically attach aspect to T.
            this.Manage<T>();
        }
        override protected Advice Advise(Type type, MethodInfo method)
        {
            //define an advice to trigger only when method execution not failed
            return new After.Returning(() => 
            {
                if (MethodCalled != null)
                {
                    MethodCalled(this, null);
                }
            }
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
