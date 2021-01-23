    class MyProducer
    {
        private System.Threading.Tasks.Dataflow.BufferBlock<T> bufferBlock = new BufferBlock<T>();
        public ISourceBlock<T> Output {get {return this.bufferBlock;}
        public async ProcessAsync()
        {
            while (somethingToProduce)
            {
                T producedData = ProduceOutput(...)
                await this.bufferBlock.SendAsync(producedData);
            }
        }
    }
