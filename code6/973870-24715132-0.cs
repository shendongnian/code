    // assuming stream is your TextReader
    using (FileStream fs = File.OpenWrite(@"FileLocation")
    {
       while (!stream.EndOfStream)
       {
            var line = stream.ReadLine();
            var lineBytes = Encoding.UTF8.GetBytes(line);
            fs.Write(lineBytes, 0, lineBytes.Length);
       }
       stream.Dispose();
    }
