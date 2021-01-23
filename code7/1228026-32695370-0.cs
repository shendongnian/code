    using System.Runtime.CompilerServices;
    using System;
    [assembly: InternalsVisibleTo("AssemblyB")]
    // The class is internal by default.
    class FriendClass
    {
        public void Test()
        {
            Console.WriteLine("Sample Class");
        }
    }
    // Public class that has an internal method.
    public class ClassWithFriendMethod
    {
        internal void Test()
        {
            Console.WriteLine("Sample Method");
        }
    }
