     public class Metrics : IMetrics
        {
            private IMetrics metrics;
    
            public Metrics(IMetrics metrics)
            {
                this.metrics = metrics;
            }
        }  
