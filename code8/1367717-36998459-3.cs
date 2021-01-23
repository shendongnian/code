    public class FakeSubs : ISimpleSubscription
    {
        public FakeSubs()
        {
        }
        // Here you have to implement ISimpleSubscription. 
        // You could also define any properties, methods etc.
    }
    // Now you could use your generic class as below:
    var simpleGetter = new SimpleGetter<FakeSubs>();
