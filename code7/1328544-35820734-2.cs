    public class ActionAggregate
    {
        private readonly ActionAggregate _parent;
        private readonly Action _action;
        public ActionAggregate()
        {        }
        
        public ActionAggregate(Action action, ActionAggregate parent)
        {
            if (action == null)
                throw new ArgumentNullException(paramName: nameof(action));
            if (parent == null)
                throw new ArgumentNullException(paramName: nameof(parent));
            this._action = action;
            this._parent = parent;
        }
        public void Invoke()
        {
            var ancestorsAndSelfFromTheTop = this.GetSelfAndAncestors().Reverse();
            foreach (var item in ancestorsAndSelfFromTheTop)
            {
                if (item._action != null)
                    item._action();
            }
        }
        private IEnumerable<ActionAggregate> GetSelfAndAncestors()
        {
            var cur = this;
            do
            {
                yield return cur;
                cur = cur._parent;
            }
            while (cur != null);
        }
    }
    public class MyActionAggregate : ActionAggregate
    {
        public MyActionAggregate()
        {        }
        
        public MyActionAggregate(Action action, ActionAggregate parent) : base(action, parent)
        {        }
                
        public MyActionAggregate With(Int32 value)
        {
            return new MyActionAggregate(
                action: () =>
                    Console.WriteLine($"There was an int value of '{value}'"),
                parent: this);
        }
        public MyActionAggregate With(String value)
        {
            return new MyActionAggregate(
                action: () =>
                    Console.WriteLine($"There was a string value of '{value}'"),
                parent: this);
        }
        public MyActionAggregate With(String[] value)
        {
            return new MyActionAggregate(
                action: () =>
                    Console.WriteLine($"There was a string[] value of '{String.Join(", ", value)}'"),
                parent: this);
        }
    }
...
    public class BusinessObject
    {
        public MyActionAggregate GetActionRoot()
        {
            return new MyActionAggregate();
        }
    }
