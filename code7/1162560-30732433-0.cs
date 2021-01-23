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
                    var encoding = Encoding.Default;                
                    Console.SetIn(new StreamReader(Console.OpenStandardInput(short.MaxValue), encoding));
                    Console.SetOut(new StreamWriter(Console.OpenStandardOutput(short.MaxValue), encoding));
                    int c;
                    var sb = new StringBuilder();
                    while ((c = Console.Read()) >= 0)
                    {
                        sb.Append((char)c);
                    }
                    Console.Write(sb.ToString());
                    Console.Error.WriteLine("[{0}] Input length: {1}", pid, sb.Length);
                    var tmp = Path.GetTempFileName();
                    File.WriteAllText(tmp, sb.ToString(), encoding);
                    Console.Error.WriteLine("[{0}] Piped input written to: ", pid);
                    Console.Error.WriteLine("[{0}] {1} (File Size={2})", pid, tmp, new FileInfo(tmp).Length);
                    Console.Out.Flush();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
        }
    }
    
    
