    public class Trigger
        {
            private readonly List<Task> TaskActions = new List<Task>();
    
            public void AddAction(IAction action)
            {
                TaskActions.Add(new Task(()=>{action.Execute();})
            }
    
            public void CheckConditions()
            {
                if (AllConditionsMet())
                {
                    ExecuteAllActions();
                }
            }
    
            private void ExecuteAllActions()
            {
                foreach(Task task in TaskActions)
                {
                    task.Start();
                }
                Task.WaitAll(TaskActions);
            }
    
            protected abstract bool AllConditionsMet();
        }
