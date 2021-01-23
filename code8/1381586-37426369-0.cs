    class Program
    {
        static void Main(string[] args)
        {
            Bar myBar = new Bar() { ObjectId = 5 };
            IFoo myFoo = myBar as IFoo;
            int myId = myFoo.ObjectId;
            Console.WriteLine(myId); // 5
            Console.ReadLine();
        }
    }
    interface IFoo
    {
        int ObjectId { get; }
    }
    class Bar : IFoo
    {
        public int ObjectId { get; set; }
    }
