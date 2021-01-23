    public class Person
    {
        IUnityContainer unityContainer;
        public Person(IUnityContainer _unityContainer)  
        {
          unityContainer=_unityContainer;
          staticObject = unityContainer.Resolve<Person>();
        }
    
        private static Person staticObject;
    
        public static Person StaticObject
        {
            get { return staticObject; }
            set { staticObject = value; }
        }
    }
