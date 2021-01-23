        public class MyType
        {
            private int? value;
            private Dictionary<int, List<Action>> actions = new Dictionary<int, List<Action>>();
            private BlockingCollection<Action> toExecute = new BlockingCollection<Action>();
            public void ExecuteActions()
            {
                Task.Run(() =>
                {
                    while (!toExecute.IsCompleted)
                    {
                        try
                        {
                            Action action = toExecute.Take();
                            action();
                        }
                        catch { }
                    }
                });
            }
            void Set(int i)
            {
                if (value == null)
                {
                    lock (this)
                    {
                        if (value == null)
                        {
                            ExecuteActions();
                            value = i;
                            List<Action> list;
                            if (actions.TryGetValue(i, out list))
                            {
                                foreach (Action action in list)
                                    toExecute.Add(action);
                            }
                        }
                    }
                }
            }
            void AddHandler(int i, Action action)
            {
                lock (this)
                {
                    if (value == i)
                    {
                        toExecute.Add(action);
                    }
                    else
                    {
                        List<Action> list;
                        if (!actions.TryGetValue(i, out list))
                        {
                            actions[i] = list = new List<Action>();
                        }
                        list.Add(action);
                    }
                }
            }
        }
