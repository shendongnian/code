    class Consumer
    {
        public IBehavior Behavior { get; set; }
    }
    // Keep reference to behavior somewhere handy
    var behavior = new Proxy { Behavior = new BasicBehavior() };
    var myConsumer = new Consumer { Behavior = behavior };
    // Now myConsumer is using Basic Behavior
    behavior.Strategy = new AdvancedBehavior();
    // ...and now myConsumer is using Advanced Behavior
