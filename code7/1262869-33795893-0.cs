        using (var fs = File.Open("test.file", FileMode.Open))
        {
            var unpacker = Unpacker.Create(fs, true);
            unpacker.Read();
            var opts = unpacker.Unpack<Options>();
            Console.WriteLine(opts.RecordLog);
            Console.WriteLine(opts.ConfigFile);
        }
