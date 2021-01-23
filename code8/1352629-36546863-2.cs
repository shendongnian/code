    var list = new List<int>();
    using (var reader = File.OpenText("MyFileName.txt"))
    {
        while (true)
        {
            string line = reader.ReadLine();
            if (line == null)
                break;
            list.Add(int.Parse(line));
        }
    }
