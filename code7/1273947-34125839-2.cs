    class Program
    {
        static void Main(string[] args)
        {
            NamedPipeServerStream pipe = new NamedPipeServerStream("ConsoleProxyPipe",
                PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            Console.Title = "Main Process";
            Process process = new Process();
            process.StartInfo.FileName = "ConsoleProxy.exe";
            process.StartInfo.Arguments = "ConsoleApplication1.exe ConsoleProxyPipe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            pipe.WaitForConnection();
            using (TextReader reader = new StreamReader(pipe))
            using (TextWriter writer = new StreamWriter(pipe))
            {
                Task readerTask = ConsumeReader(reader);
                string line;
                do
                {
                    line = Console.ReadLine();
                    writer.WriteLine(line);
                    writer.Flush();
                } while (line != "");
                readerTask.Wait();
            }
        }
        static async Task ConsumeReader(TextReader reader)
        {
            char[] rgch = new char[1024];
            int cch;
            while ((cch = await reader.ReadAsync(rgch, 0, rgch.Length)) > 0)
            {
                Console.Write(rgch, 0, cch);
            }
        }
    }
