    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    // Be sure to run this 32-bit to avoid making your system unstable.
    class StreamProcessor
    {
        Stream GetStream(string streamPosition)
        {
            var parsedStreamPosition = Convert.ToInt32(streamPosition);
            return new Stream(
                // Terminate after we reach 0.
                parsedStreamPosition > 0 ? new[] { streamPosition, } : new string[] { },
                Convert.ToString(parsedStreamPosition - 1));
        }
    
        Task ProcessItem(string item)
        {
            // Comment out this next line to make things go faster.
            Console.WriteLine(item);
            // Simulate the Task represented by ProcessItem finishing in
            // time to make the await continue synchronously.
            return Task.CompletedTask;
        }
    
        public async Task<string> ProcessStream(string streamPosition)
        {
            var stream = GetStream(streamPosition);
    
            if (stream.Items.Count == 0)
                return stream.NextPosition;
    
            foreach (var item in stream.Items)
            {
                await ProcessItem(item); //ProcessItem() is now an async method
            }
    
            // Without this yield (which prevents inline synchronous
            // continuations which quickly eat up the stack),
            // you get a StackOverflowException fairly quickly.
            // With it, you get an OutOfMemoryException eventually—I bet
            // that “return await” isn’t able to tail-call properly at the Task
            // level or that TPL is incapable of collapsing a chain of Tasks
            // which are all set to resolve to the value that other tasks
            // resolve to?
            await Task.Yield();
    
            return await ProcessStream(stream.NextPosition);
        }
    }
    
    class Program
    {
        static int Main(string[] args) => new Program().Run(args).Result;
        async Task<int> Run(string[] args)
        {
            await new StreamProcessor().ProcessStream(
                Convert.ToString(int.MaxValue));
            return 0;
        }
    }
    
    class Stream
    {
        public IList<string> Items { get; }
        public string NextPosition { get; }
        public Stream(
            IList<string> items,
            string nextPosition)
        {
            Items = items;
            NextPosition = nextPosition;
        }
    }
