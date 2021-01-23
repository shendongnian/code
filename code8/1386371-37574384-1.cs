    static void Main(string[] args) {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        EventHandler handler = new EventHandler(sig => {
            // may want to investigate signal here
            // cancel if appropriate
            cts.Cancel();
            return true;
        });
        // this is from your linked answer
        SetConsoleCtrlHandler(handler, true);
        while (!cts.IsCancellationRequested) {
            Console.WriteLine("doing stuff");
            var cancelled = token.WaitHandle.WaitOne(30000);
            if (cancelled) {
                // handle exit
                Console.WriteLine("Cancelled!");
                break;
            }
        }
    }
