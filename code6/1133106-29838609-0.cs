    using System;
    using System.Diagnostics;
    using Castle.DynamicProxy;  //Remember to include a reference, too.  It's nugettable package is Castle.Core
    namespace ConsoleApp
    {
        public class ActualClass
        {
            //Have static instances of two below for performance
            private static ProxyGenerator pg = new ProxyGenerator();
            private static ActualClassInterceptor interceptor = new ActualClassInterceptor();
            //This is how we get ActualClass items that are wrapped in the Dynamic Proxy
            public static ActualClass getActualClassInstance()
            {
                ActualClass instance = new ActualClass();
                return pg.CreateClassProxyWithTarget<ActualClass>(instance, interceptor);
            }
            //Tracking whether init has been called
            private bool initialized = false;
            //Will be used as evidence of true initialization, i.e. no longer null
            private int? someValue = null;
            public void Initialize()
            {
                if (!initialized)
                {
                    //do some initialization here.
                    someValue = -1; //Will only get set to non-null if we've run this line.
                    initialized = true;
                }
            }
            //Any methods you want to intercept need to be virtual!
            public virtual int replaceValue(int value) 
            {
                //below will blow up, if someValue has not been set to -1 via Initialize();
                int oldValue = someValue.Value;
                someValue = value;
                return oldValue;
            }
            //block off constructor from public to enforce use of getActualClassInstance
            protected ActualClass() { }
        }
        public class ActualClassInterceptor : ActualClass, IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                //Call initialize before proceeding to call the intercepted method
                //Worth noting that this is the only place we actually call Initialize()
                ((ActualClass)invocation.InvocationTarget).Initialize();
                invocation.Proceed();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                ActualClass instance1 = ActualClass.getActualClassInstance();
                ActualClass instance2 = ActualClass.getActualClassInstance();
                int x1 = instance1.replaceValue(41);
                int x2 = instance2.replaceValue(42);
                int y1 = instance1.replaceValue(82);
                Debug.Assert(y1 == 41);
                int y2 = instance2.replaceValue(84);
                Debug.Assert(y2 == 42);
                var read = Console.ReadKey();
            }
        }
    }
