    internal interface ITest
    {
        Action GetData{ get; set; }
    }
    internal class Test : ITest
    {
        public Action GetData  { get; set; }
    }
