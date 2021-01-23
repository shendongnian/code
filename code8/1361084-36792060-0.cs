    public class SimpleLoop
    {
        public int I { get; set; }
        public Predicate<int> Condition { get; set; }
        public int Increment { get; set; }
        public Func<int, bool> Action { get; set; }
        public SimpleLoop(int i, Predicate<int> condition, int increment, Func<int, bool> action)
        {
            I = i;
            Condition = condition;
            Increment = increment;
            Action = action;
            Invoke();
        }
        private void Invoke()
        {
            for (int i = I; Condition.Invoke(i); i += Increment)
            {
                if (!Action.Invoke(i))
                    break;
            }
        }
    }
