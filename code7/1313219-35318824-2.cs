    using(StreamReader sr = new StreamReader(...)) {
        while(!sr.EndOfStream) {
            string line = sr.ReadLine();
            Console.WriteLine(line);
        }
    }
