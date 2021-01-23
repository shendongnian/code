         public class MyEventProcessor : IEventProcessor
        {
            Stopwatch checkpointStopWatch;            
    
            //TODO: get provider id from parent class     
        IParameters _parameter;
        public MyEventProcessor (IParameters param)
        {
          this._parameter  = param;
         }
    
            public async Task CloseAsync(PartitionContext context, CloseReason reason)
            {
                Debug.WriteLine("Processor Shutting Down. Partition '{0}', Reason: '{1}'.", context.Lease.PartitionId, reason);
                if (reason == CloseReason.Shutdown)
                {
                    await context.CheckpointAsync();
                }
            }.....
    
       
