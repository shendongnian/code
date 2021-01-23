    public static async Task ProcessFile(string sourceFileName,string targetFileName)
    {
        //Pass the target stream as part of the message to avoid globals
        var block = new ActionBlock<Tuple<string, FileStream>>(async tuple =>
        {
            var line = tuple.Item1;
            var stream = tuple.Item2;
            await stream.WriteAsync(Encoding.UTF8.GetBytes(line), 0, line.Length);
        });
        //Post lines to block
        using (var targetStream = new FileStream(targetFileName, FileMode.Append, 
                                       FileAccess.Write, FileShare.Write, 16392))
        {
            using (var sourceStream = File.OpenRead(sourceFileName))
            {
                await PostLines(sourceStream, targetStream, block);
            }
            //Tell the block we are done
            block.Complete();
            //And wait fo it to finish
            await block.Completion;
        }
    }
    private static async Task PostLines(FileStream sourceStream, FileStream targetStream, 
                                        ActionBlock<Tuple<string, FileStream>> block)
    {
        using (var reader = new StreamReader(sourceStream))
        {
            while (true)
            {
                var line = await reader.ReadLineAsync();
                if (line == null)
                    break;
                var tuple = Tuple.Create(line, targetStream);
                block.Post(tuple);
            }
        }
    }
