    public class TrackedBody
    {     
        public Task BeginTrackingAsync(CancellationToken cancellation)
        {
            return Task.Run(() => RunBiometricsThread(cancellation));
        }
    
        private void RunBiometricsThread(CancellationToken cancellation)
        {
            while(!cancellation.IsCancellationRequested) 
            {
                Task.Delay(1000, cancellation);
            }
        }
    }
