    static void Main()
    {
        using (StreamReader reader = new StreamReader(@"yourFile"))
        {
            int offset = 0;
            int bufferSize = 102400;
            int length = (int)reader.BaseStream.Length;
            byte[] file = new byte[length];
            while (!reader.EndOfStream)
            {
                // Add this line:
                Console.WriteLine(reader.BaseStream.Position);
                Console.ReadLine();
                int readBytes = reader.BaseStream.Read(file, 0,
                    (length - offset) > bufferSize ? bufferSize : (length - offset));
                string str = Encoding.UTF8.GetString(file, 0, readBytes);
                offset += readBytes;
                if (reader.BaseStream.Position == length)
                {
                    Console.WriteLine("I'm at the end of the file!  Current Tickcount: " + Environment.TickCount);
                    Thread.Sleep(100);
                }
            }
        }
    }
