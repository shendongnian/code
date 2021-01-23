        public class MyType
        {
            private HashSet<int> set = new HashSet<int>();
            private Dictionary<int, BlockingCollection<Action>> actions = new Dictionary<int, BlockingCollection<Action>>();
            private void ExecuteActions(BlockingCollection<Action> toExecute)
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
            public void Set(int i)
            {
                lock (this)
                {
                    if (!set.Contains(i))
                    {
                        set.Add(i);
                        BlockingCollection<Action> toExecute;
                        if (!actions.TryGetValue(i, out toExecute))
                        {
                            actions[i] = toExecute = new BlockingCollection<Action>();
                        }
                        ExecuteActions(toExecute);
                    }
                }
            }
            public void AddHandler(int i, Action action)
            {
                lock (this)
                {
                    BlockingCollection<Action> toExecute;
                    if (!actions.TryGetValue(i, out toExecute))
                    {
                        actions[i] = toExecute = new BlockingCollection<Action>();
                    }
                    toExecute.Add(action);
                }
            }
        }
