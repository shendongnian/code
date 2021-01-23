    interface IBehavior
    {
        int DoFoo();
    }
    class Proxy : IBehavior
    {
        public IBehavior Strategy { get; set; }
        public int DoFoo()
        {
            return Strategy.DoFoo();
        }
    }
    class BasicBehavior : IBehavior { ... }
    class AdvancedBehavior : IBehavior { ... }
