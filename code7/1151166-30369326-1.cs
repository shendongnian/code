    public sealed class MyTelevision
        : Television
    {
        public override void TurnOn()
        {
            Console.WriteLine("Turn on my tv");
        }
        public override void TurnOff()
        {
            Console.WriteLine("Turn off my tv");
        }
        protected override void Draw()
        {
            // code here.
        }
    }
