    [assembly: InternalsVisibleTo("AssemblyB")]
    
    // The class is internal by default.
    class FriendClass
    {
        public void Test()
        {
            Console.WriteLine("Sample Class");
        }
    }
    
