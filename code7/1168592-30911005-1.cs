    public class MyClassB : IMyInterface
    {
        int IMyInterface.PropA { get { return this.PropB; } set { this.PropB = value; } }
        public int PropB { get; set; }
    }
