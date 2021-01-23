    [Guid("0B301484-E388-45eb-9AB8-A6AE1E197BBA")]
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
