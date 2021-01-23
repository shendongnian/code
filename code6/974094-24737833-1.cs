    [ServiceBehavior( InstanceContextMode = InstanceContextMode.Single)]
    public class MyService : IMyService
    {
        public MyService()
        {
            //Pay attention to this, the rest of this class is fluff.
            Singleton<MyService>.SetSingleton(this);
        }
        public String Hello(String Name)
        {
            return "Hello " + Name;
        }
        public Person GetPerson()
        {
            return new Person() { Age = 21 };
        }
    }
