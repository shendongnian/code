    public class A
    {
        ...
        private void LaunchB()
        {
            var bObj = new B();
            bObj.OnTaskCompleted += TaskCompleted;
            bObj.StartWorking(); //some method call here
        }
        private void TaskCompleted(string status)
        {
            //notification from B comes
        }
        ...
    }
    public class B
    {
        public delegate void TaskCompletedHandler(string status);
        public event TaskCompletedHandler OnTaskCompleted;
        private void DoWork()
        {
            if(completed)
            {
                ...
                if (OnTaskCompleted != null)
                {
                   OnTaskCompleted("SUCCESS");
                }
            }
        }
    }
