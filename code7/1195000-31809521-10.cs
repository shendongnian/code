    public class MyConsumer<T>
    {
        ISourceBlock<T> Source {get; set;}
        public async Task ProcessAsync()
        {
            while (await this.Source.OutputAvailableAsync())
            {   // there is input of type T, read it:
	            var input = await this.Source.ReceiveAsync();
                // process input
            }
            // if here, no more input expected. finish.
        }
    }
