    namespace myNamespace
    {
        public class myClass
        {
            private GlobalObject myGlobalInstance;
            public void myMethod()
            {
                doSomthing(myGlobalObject);
            }
            private String doSomthing(GlobalObject myObjectInstance)
            {
                GlobalObject newObject = myObjectInstance.Copy();
                newObject.variable1 = "boo";
            }
        }
    }
