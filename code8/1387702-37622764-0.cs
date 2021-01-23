    public class NotifyingTaskRunner
    {
        public event EventHandler<TaskResultEventArgs> TaskCompleted;
        public void RunAndNotify(Task<bool> task)
        {
            task.ContinueWith(t =>
            {
                OnTaskCompleted(this, new TaskResultEventArgs { Result = t.Result });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }
        protected virtual void OnTaskCompleted(object sender, TaskResultEventArgs e)
        {
            var h = TaskCompleted;
            if (h != null)
            {
                h.Invoke(sender, e);
            }
        }
    }
