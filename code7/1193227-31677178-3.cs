       using System.Windows.Forms.Timer;
    
      public class Task
    {
        Timer timer;
        public static Task Delay(TimeSpan timeSpan)
        {
            Task task = new Task();
            task.timer = new Timer();
            task.timer.Interval = Convert.ToInt32(timeSpan.TotalMilliseconds);
            return task;
        }
        private Task()
        {
        }
        public static Task Delay(int miliSeconds)
        {
            Task task = new Task();
            task.timer = new Timer();
            task.timer.Interval = miliSeconds;
            return task;
        }
        public static void Run(Action action)
        {
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Enabled = true;
            timer.Tick += delegate
            {
                timer.Stop();
                timer = null;
                action();
            };
        }
        EventHandler elapsed;
        public void ContinueWith(Action action)
        {
            timer.Enabled = true;
            elapsed = delegate
            {
                Stop();
                action();
            };
            //bind the event
            timer.Tick += elapsed;
        }
        private void handleEvent(Action action)
        {
        }
        public void Stop()
        {
            timer.Stop();
            timer.Enabled = false;
            //unbind the event
            if (elapsed != null)
            {
                timer.Tick -= elapsed;
            }
        }
    }
