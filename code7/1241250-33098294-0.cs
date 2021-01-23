    // NOTE: as a sample program, contrary to normal and correct
    // programming practices error-handling has been omitted, and
    // non-awaited async methods have been declared as void.
    class Program
    {
        private const string _kserverName = "TestSO33093954NamedPipeClients";
        private const int _kmaxServerCount = 3;
        private const int _kmaxClientCount = 3;
        static void Main(string[] args)
        {
            StartServers(_kmaxServerCount);
            StartClients(_kmaxClientCount);
            Console.WriteLine("Clients are being started. Press return to exit program.");
            Console.ReadLine();
        }
        private static async void StartClients(int clientCount)
        {
            for (int i = 0; i < clientCount; i++)
            {
                RunClient(i);
                await Task.Delay(300);
            }
        }
        private static async void RunClient(int instance)
        {
            NamedPipeClientStream client = new NamedPipeClientStream(
                ".", _kserverName, PipeDirection.InOut, PipeOptions.Asynchronous);
            client.Connect();
            ReadClient(client);
            using (StreamWriter writer = new StreamWriter(client))
            {
                writer.AutoFlush = true;
                for (int i = 0; i < 5; i++)
                {
                    string text =
                        string.Format("Instance #{0}, iteration #{1}", instance, i);
                    Console.WriteLine("Client send: " + text);
                    await writer.WriteLineAsync(text);
                    await Task.Delay(1000);
                }
                client.WaitForPipeDrain();
            }
        }
        private static async void ReadClient(Stream stream)
        {
            using (TextReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    Console.WriteLine("Client recv: " + line);
                }
            }
        }
        private static void StartServers(int maxServerInstances)
        {
            for (int i = 0; i < maxServerInstances; i++)
            {
                RunServer(maxServerInstances);
            }
        }
        private static async void RunServer(int maxServerInstances)
        {
            while (true)
            {
                using (NamedPipeServerStream server = new NamedPipeServerStream(
                    _kserverName, PipeDirection.InOut, maxServerInstances,
                     PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
                {
                    await server.WaitForConnectionAsync();
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    Decoder decoder = Encoding.UTF8.GetDecoder();
                    while ((bytesRead =
                        await server.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        int cch = decoder.GetCharCount(buffer, 0, bytesRead);
                        char[] rgch = new char[cch];
                        decoder.GetChars(buffer, 0, bytesRead, rgch, 0);
                        Console.Write("Server recv: " + new string(rgch));
                        await server.WriteAsync(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
    static class PipeExtensions
    {
        // As I am not running with .NET 4.6 yet, I need this little helper extension
        // to wrap the APM-based asynchronous connection-waiting with the await-friendly
        // Task-based syntax. Anyone using .NET 4.6 will have this in the framework already
        public static Task WaitForConnectionAsync(this NamedPipeServerStream server)
        {
            return Task.Factory.FromAsync(
                server.BeginWaitForConnection, server.EndWaitForConnection, null);
        }
    }
