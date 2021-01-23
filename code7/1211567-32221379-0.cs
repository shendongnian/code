    var fileName = "test.txt";
    using (var fsWrite = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
    {
        var content = Encoding.UTF8.GetBytes("test");
        fsWrite.Write(content, 0, content.Length);
        fsWrite.Flush();
        using (var fsRead_1 = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            var bufRead_1 = new byte[fsRead_1.Length];
            fsRead_1.Read(bufRead_1, 0, bufRead_1.Length);
            Console.WriteLine("fsRead_1:" + Encoding.UTF8.GetString(bufRead_1));
            using (var fsRead_2 = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var bufRead_2 = new byte[fsRead_2.Length];
                fsRead_2.Read(bufRead_2, 0, bufRead_2.Length);
                Console.WriteLine("fsRead_2:" + Encoding.UTF8.GetString(bufRead_2));
            }
        }
    }
