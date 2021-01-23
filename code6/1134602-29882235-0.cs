    using System;
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var buf = new char[4096];
                while (true)
                {
                    int read = Console.In.Read(buf, 0, buf.Length);
                    if (read == 0)
                        break;
                    for (int i = 0; i < read; i++)
                        buf[i] = char.ToUpper(buf[i]);
                    Console.Out.Write(buf, 0, read);
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("ERROR: " + e.Message);
                return 1;
            }
        }
    }
