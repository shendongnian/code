    public class ConditionalAction
    {
        public ConditionalAction(Action action, Func<Boolean> predicate)
        {
            this.Action = action;
            this.Predicate = predicate;
        }
        public Action Action { get; private set; }
        public Func<Boolean> Predicate { get; private set; }
    }
