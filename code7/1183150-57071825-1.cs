csharp
    public class Program
    {
        [CoreJob]
        [RPlotExporter, RankColumn, MemoryDiagnoser]
        public class CollectionsContains
        {
            private const string SearchedMessage = "hello world";
            [Params(1, 1_000, 100_000)]
            private int N;
            [Params(true, false)]
            private bool SearchedQueryIsMatch;
            [Benchmark]
            public void ExceptionFilter() => ExecuteTestFor(exception =>
            {
                try
                {
                    throw exception;
                }
                catch (Exception ex) when (ex.Message == SearchedMessage)
                {
                }
            });
            [Benchmark]
            public void IfStatement() => ExecuteTestFor(exception =>
            {
                try
                {
                    throw exception;
                }
                catch (Exception ex)
                {
                    if (ex.Message == SearchedMessage)
                    {
                        return;
                    }
                    throw;
                }
            });
            private void ExecuteTestFor(Action<Exception> testedExceptionHandling)
            {
                for (int i = 0; i < N; i++)
                {
                    try
                    {
                        var exception = new Exception(SearchedQueryIsMatch ? SearchedMessage : Guid.NewGuid().ToString());
                        testedExceptionHandling(exception);
                    }
                    catch
                    {
                    }
                }
            }
        }
        private static void Main() => BenchmarkRunner.Run<CollectionsContains>();
    }
