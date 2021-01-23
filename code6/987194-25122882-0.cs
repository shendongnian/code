    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string fileName = "c:\\_data\\temp.txt";
    
                Task writer = new Task(() => {
    
                    using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (int i = 0; i < 50; i++ )
                        {
                            sw.WriteLine(DateTime.Now.Millisecond.ToString());
                            sw.Flush();
                            Thread.Sleep(500);
                        }
                    }
    
    
                });
    
                Task reader = new Task(() => {
                    for (int i = 0; i < 50; i++)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("Read again");
                        if (File.Exists(fileName))
                        {
                            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                            using (StreamReader r = new StreamReader(fs))
                            {
                                while (!r.EndOfStream)
                                {
                                    Console.WriteLine(r.ReadLine());
                                }
                            }
                        }
                    }
                });
    
                writer.Start();
                reader.Start();
    
                writer.Wait();
                reader.Wait();
            }
        }
    }
