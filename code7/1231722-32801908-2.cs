    BlockingCollection<string> blocking_collection = new BlockingCollection<string>(10); 
    using (StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read)))
    {
        using (
            StreamWriter writer =
                new StreamWriter(new FileStream(success_filename, FileMode.OpenOrCreate, FileAccess.Write)))
        {
            var input_task = Task.Factory.StartNew(() =>
            {
                try
                {
                    while (!reader.EndOfStream)
                    {
                        blocking_collection.Add(reader.ReadLine());
                    }
                }
                finally //In all cases, even in the case of an exception, we need to make sure that we mark that we have done adding to the collection so that the Parallel.ForEach loop will exit. Note that Parallel.ForEach will not exit until we call CompleteAdding
                {
                    blocking_collection.CompleteAdding();
                }
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
            input_task.Wait(); //This will make sure that exceptions thrown in the input thread will be propagated here
        }
    }
