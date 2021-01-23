    namespace MyThings
    {
      public class Thing
      {
        private string thingName = "default name";
        public string ThingName
        {
          get { return thingName; }
          private set { thingName = value; }
        }
        public Thing(string name)
        {
          thingName = name;
        }
        public SayThing()
        {
          string thingsToSay = thingName + " and things.";  // Set breakpoint here
          Console.WriteLine("I have some {0}", thingsToSay);
        }
      }
      public static class Program
      {
        public static void Main()
        {
           var thing = new Thing("My thing");
           thing.SayThing();
        }
      }
    }
