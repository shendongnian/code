    [Guid("68FAB6AC-9923-425a-85F2-59B50552A5C1")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class Thingy: IThingy
    {
        [ComVisible(true)]
        public int DoThing1(string name, int age)
        {
            // ....
        }
    
        [ComVisible(true)]
        public string DoThing2(int id)
        {
            // ....
        }
    
        [ComVisible(true)]
        public bool DoThing3(string address)
        {
            // ....
        }
    }
