    public class TestModule : NancyModule
    {
        static CancellationTokenSource cts = new CancellationTokenSource();
        static CancellationToken cToken = cts.Token;
        public TestModule()
        {
            Get["/run", true] = async (parameters, ct) =>
            {
                Algorithm ag = new Algorithm();
                Console.Write("Running Algorithm...\n");
                var result = await Task.Run(() => ag.RunAlgorithm(cToken), cToken);
                return Response.AsText(result.ToString());
            };
            Get["/cancel"] = _ =>
            {
                Console.Write("Cancel requested recieved\n");
                cts.Cancel();
                cts.Dispose();
                cts = new CancellationTokenSource();
                cToken = cts.Token;
                return Response.AsText("Cancelled!");
            };
        }
    }
