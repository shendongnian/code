    public class ThisThing {
        public string Stuff { get; set; }
        public int SomeMoreStuff { get; set; }
        public DateTime EvenMoreStuff { get; set; }
        // ...
        public string ThisClassIsGettingHuge { 
            get {
                return "Time to refactor because big classes tend to break SRP";
            }
        }
    }
    public class Something {
        public class SomethingElse {
            public ThisThing ThisThingAsAProperty { get; set; }
        }
    } 
