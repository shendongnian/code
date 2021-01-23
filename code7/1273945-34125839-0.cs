    class Program
    {
        static void Main(string[] args)
        {
            NamedPipeClientStream pipe = new NamedPipeClientStream(".", args[1],
                PipeDirection.InOut, PipeOptions.Asynchronous);
            pipe.Connect();
            Process process = new Process();
            process.StartInfo.FileName = args[0];
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            using (TextReader reader = new StreamReader(pipe))
            using (TextWriter writer = new StreamWriter(pipe))
            {
                Task readerTask = ConsumeReader(process.StandardOutput, writer);
                string line;
                do
                {
                    line = reader.ReadLine();
                    if (line != "")
                    {
                        line = "proxied write: " + line;
                    }
                    process.StandardInput.WriteLine(line);
                    process.StandardInput.Flush();
                } while (line != "");
                readerTask.Wait();
            }
        }
        static async Task ConsumeReader(TextReader reader, TextWriter writer)
        {
            char[] rgch = new char[1024];
            int cch;
            while ((cch = await reader.ReadAsync(rgch, 0, rgch.Length)) > 0)
            {
                writer.Write("proxied read: ");
                writer.Write(rgch, 0, cch);
                writer.Flush();
            }
        }
    }
