    <!-- language: c# -->    
    
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;
    namespace ConsolePipeConsumer
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    var pid = Process.GetCurrentProcess().Id;
                    var buffer = new byte[1024];
                    var tmp = new FileInfo(Path.GetTempFileName());
    
                    using (var reader = new BinaryReader(Console.OpenStandardInput(8192)))
                    using (var writer = new BinaryWriter(Console.OpenStandardOutput(8192)))
                    using (var tmpWriter = new BinaryWriter(tmp.Create()))
                    {
                        int c;
                        int len = 0;
                        while ((c = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            writer.Write(buffer, 0, c);
                            tmpWriter.Write(buffer, 0, c);
                            len += c;
                        }
                        Console.Error.WriteLine("[{0}] Input length: {1}", pid, len);
                        
                        Console.Error.WriteLine("[{0}] Piped input written to: ", pid);
                        Console.Error.WriteLine("[{0}] {1} (File Size={2})", pid, tmp, tmp.Length);
                        writer.Flush();
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }
    }
    
    
