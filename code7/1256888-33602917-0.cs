    [CallbackBehaviorAttribute(UseSynchronizationContext=false)]
    class Callback : ISubmissionServiceCallback
    {
        public void Pong()
        {
            Console.WriteLine("Pong!");
        }
        public void SubmissionProcessed(SubmissionResultDto result)
        {
        }
    }
