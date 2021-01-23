    public class Thing
    {
        public string ThingLabel { get; readonly set; }
        public double ThingPrice { get; readonly set; }
        public int ThingQuantity { get; readonly set; }
        // the value of your stock, calculated automatically based on other properties
        public double ThingValue { get { ThingPrice * ThingQuantity; } }
        public Thing(string thingLabel, double thingPrice, int thingQuantity)
        {
            ThingLabel = thingLabel;
            // etc
        }
    }
    public void DoStuff()
    {
        List<Thing> list = new List<Thing>();
        
        Thing thing = new Thing("Civet cat", 500, 10);
    
        list.Add(thing);
        list.Add(new Thing("Sea flap flap", 100, 5);
        list.Add(new Thing("Nope Rope", 25, 4);
        Console.WriteLine("The value of {0}'s stock is: {1}", thing.ThingLabel, thing.Value);
    }
