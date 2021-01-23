        public abstract class IObjectProvider
        {
            public abstract IObjectProvider Object{get;}
            public abstract void doStuff();
        }
        public class RealObject : IObjectProvider
        {
            public RealObject()
            {
                //Do very complicated and time taking stuff;
            }
            public override IObjectProvider Object
            {
                get { return this; }
            }
            public override void doStuff()
            {
                //do this stuff that these objects normally do 
            }
        }
        public class ObjectProxy : IObjectProvider
        {
            private RealObject objectInstance = null;
            public override IObjectProvider Object
            {
                get 
                {
                    if (objectInstance == null)
                        objectInstance = new RealObject();
                    return objectInstance; 
                }
            }
            public override void doStuff()
            {
                if(objectInstance!=null)
                    objectInstance.doStuff();
            }
        }
        public class SkeletonClass 
        {
            public IObjectProvider Proxy1 = new ObjectProxy();
            public IObjectProvider Proxy2 = new ObjectProxy();
        }
        static void Main(String[] args)
        {
            //Objects Not Loaded
            SkeletonClass skeleton = new SkeletonClass();
            //Proxy1 loads object1 on demand
            skeleton.Proxy1.Object.doStuff();
            //Proxy2 not loaded object2 until someone needs it
        }
