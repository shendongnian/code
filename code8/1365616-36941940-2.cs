    public class Step
    {
        private ISteppable SteppableObject {get; set;}
        public Step(ISteppable steppableObject)
        {
            this.SteppableObject = steppableObject;
        }
        
        // just do the step
        public void Step()
        {
            this.SteppableObject.Step();
        }
        // do the step, and control execution speed:
        public void Step(TimeSpan minExecutionTime)
        {
            var waitTask = Task.Delay(minExecutionTime);
            var stepTask = Task.Run( () => this.SteppableObject.Step());
            // wait until both the step and the wait task are ready:
            Task.WaitAll( new Task[] {waitTask, stepTask}
            // now yo know this lasted at least minExecutionTime
        }
