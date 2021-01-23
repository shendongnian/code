    using (var command = client.CreateCommand("your command text"))
    {
        var cmdAsyncResult = command.BeginExecute();
        using (var standardOutputReader = new SshCommandStreamReader(command.OutputStream))
        {
            while (!cmdAsyncResult.IsCompleted)
            {
                var result = standardOutputReader.Read();
                if (!String.IsNullOrEmpty(result))
                {
                    Console.Write(result);
                }
                // Or what ever mechanism you'd like to use to prevent CPU thrashing.
                Thread.Sleep(1);
            }
            // This must be done *after* the loop and *before* EndExecute() so that any extra output
            // is captured (e.g. the loop never ran because the command was so fast).
            var resultFinal = standardOutputReader.Read();
            if (!String.IsNullOrEmpty(resultFinal))
            {
                Console.Write(resultFinal);
            }
        }
        command.EndExecute(cmdAsyncResult);
    }
