        public class MyType
        {
            private int? value;
            private Dictionary<int, List<Action>> actions = new Dictionary<int, List<Action>>();
            void Set(int i)
            {
                if (value == null)
                {
                    lock (this)
                    {
                        if (value == null)
                        {
                            value = i;
                            List<Action> toExecute;
                            if (actions.TryGetValue(i, out toExecute))
                            {
                                foreach (Action action in toExecute)
                                    action();
                            }
                        }
                    }
                }
            }
            void AddHandler(int i, Action action)
            {
                lock(this)
                {
                    List<Action> toExecute;
                    if (!actions.TryGetValue(i, out toExecute))
                    {
                        actions[i] = toExecute = new List<Action>();
                    }
                    toExecute.Add(action);
                    if (value == i)
                        action();
                }
            }
        }
