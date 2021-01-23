    public class Result
    {
        public string Case { get; set; }
        public string State { get; set; }
        public string Investor { get; set; }
        public decimal Price { get; set; }
        public string Product { get; set; }
    }
...
    using (var reader = CreateXmlReader())
    {
        // I highly doubt that this collection will
        // ever reach its bounded capacity since
        // the processing stage takes so long,
        // but in case it does, Parallel.ForEach
        // will be throttled.
        using (var handover = new BlockingCollection<Result>(boundedCapacity: 100))
        {
            var processStage = Task.Run(() =>
            {
                try
                {
                    Parallel.ForEach(EnumerateAxis(reader, "Input"), node =>
                    {
                        // Do calc.
                        Thread.Sleep(1000);
                        // Hand over to the writer.
                        // This handover is not blocking (unless our 
                        // blocking collection has reached its bounded
                        // capacity, which would indicate that the
                        // writer is running slower than expected).
                        handover.Add(new Result());
                    });
                }
                finally
                {
                    handover.CompleteAdding();
                }
            });
            var writeStage = Task.Run(() =>
            {
                using (var writer = CreateXmlReader())
                {
                    foreach (var result in handover.GetConsumingEnumerable())
                    {
                        // Write element.
                    }
                }
            });
            // Note: the two stages are now running in parallel.
            // You could technically use Parallel.Invoke to
            // achieve the same result with a bit less code.
            Task.WaitAll(processStage, writeStage);
        }
    }
