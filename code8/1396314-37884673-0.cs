    private static void Execute1()
            {
                List<Action> actions = new List<Action>();
                for (int i = 0; i < 5; i++)
                {
                    actions.Add(new Action(() => DoSomething(i)));
                }
                Parallel.Invoke(actions.ToArray());
            }
            private static void Execute()
            {
                List<Action<int>> actions = new List<Action<int>>();
                for (int i = 0; i < 5; i++)
                {
                    actions.Add(new Action<int>((x) => DoSomething(i)));
                }
                for (int i = 0; i < actions.Count; i++)
                {
                    Parallel.Invoke(() => { actions[0](0); });
                }
            }
