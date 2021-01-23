    [MyAttribute]
    public class MyWrapper : IMyThing
    {
        private readonly IMyThing _myThing;
        public MyWrapper()
        {
            _myThing = new MyThing();
        }
        
        public void DoMyThingStuff()
        {
            _myThing.DoMyThingStuff();
        }
    }
    
