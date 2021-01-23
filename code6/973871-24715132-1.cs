    // assuming stream is your TextReader
    using (stream)
    using (StreamWriter sw = File.CreateText(@"FileLocation"))
    {
       while (!stream.EndOfStream)
       {
            var line = stream.ReadLine();
            sw.WriteLine(line);
        }
    }
