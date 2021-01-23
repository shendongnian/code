    BlockingCollection<string> blocking_collection = new BlockingCollection<string>(10); 
    using (StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read)))
    {
        using (
            StreamWriter writer =
                new StreamWriter(new FileStream(success_filename, FileMode.OpenOrCreate, FileAccess.Write)))
        {
            var input_task = Task.Factory.StartNew(() =>
            {
                while (!reader.EndOfStream)
                {
                    blocking_collection.Add(reader.ReadLine());
                }
                blocking_collection.CompleteAdding();
            });
            Parallel.ForEach(blocking_collection.GetConsumingEnumerable(), (line) =>
            {
                bool test_reault = Test(line);
                if (test_reault)
                {
                    lock (writer)
                    {
                        writer.WriteLine(line);
                    }
                }
            });
                    
        }
    }
