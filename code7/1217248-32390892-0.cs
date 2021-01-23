        static async Task DownloadData(IEnumerable<string> urls)
        {
            // we want to execute this in parallel
            var executionOptions = new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
            
            // this block will receive URL and download content, pointed by URL
            var donwloadBlock = new TransformBlock<string, Tuple<string, string>>(async url =>
            {
                using (var client = new HttpClient())
                {
                    var content = await client.GetStringAsync(url);
                    return Tuple.Create(url, content);
                }
            }, executionOptions);
            // this block will print number of bytes downloaded
            var outputBlock = new ActionBlock<Tuple<string, string>>(tuple =>
            {
                Console.WriteLine($"Downloaded {(string.IsNullOrEmpty(tuple.Item2) ? 0 : tuple.Item2.Length)} bytes from {tuple.Item1}");
            }, executionOptions);
            // here we tell to donwloadBlock, that it is linked with outputBlock;
            // this means, that when some item from donwloadBlock is being processed, 
            // it must be posted to outputBlock
            using (donwloadBlock.LinkTo(outputBlock))
            {
                // fill downloadBlock with input data
                foreach (var url in urls)
                {
                    await donwloadBlock.SendAsync(url);
                }
                // tell donwloadBlock, that it is complete; thus, it should start processing its items
                donwloadBlock.Complete();
                // wait while downloading data
                await donwloadBlock.Completion;
                // tell outputBlock, that it is completed
                outputBlock.Complete();
                // wait while printing output
                await outputBlock.Completion;
            }
        }
        static void Main(string[] args)
        {
            var urls = new[]
            {
                "http://www.microsoft.com",
                "http://www.google.com",
                "http://stackoverflow.com",
                "http://www.amazon.com",
                "http://www.asp.net"
            };
            Console.WriteLine("Start now.");
            DownloadData(urls).Wait();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
