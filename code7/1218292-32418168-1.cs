    var demo = (DemoClass)System.Runtime.Serialization
                          .FormatterServices.GetSafeUninitializedObject(typeof(DemoClass));
    Console.WriteLine("PROP=" + demo.Prop);
----
    public class DemoClass
    {
        public int Prop = 5;
        public DemoClass()
        {
            Prop = 6;
        }
    }
