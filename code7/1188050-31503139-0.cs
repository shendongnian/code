    public class Thing
    {
        public readonly static List<Thing> AllTheThings = new List<Thing>();
        
        //making the constructor private so that no other code can call it.
        private Thing() {  }
    
        //providing a static instance method for creating the object
        public static Thing Instance()
        {
            var t = new Thing();
            Thing.AllTheThings.Add(t);
             return t;
        }
    }
