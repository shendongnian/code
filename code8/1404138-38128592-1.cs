    // Public class that has an internal method.
    public class ClassWithFriendMethod
    {
        internal void Test()
        {
            Console.WriteLine((new FriendClass).Test);
        }
    
    }
