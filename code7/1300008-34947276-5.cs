    public class Buffer<T>
    {
        IMemoryBlock<T> buffer;
        public Buffer(**params**)
        {
            buffer = (**conditions**) 
                ? CreateMemoryBlockPreferDisk() 
                : new RamMemoryBlock<T>();
        }
        protected virtual IMemoryBlock<T> CreateMemoryBlockPreferDisk()
        {
            return new RamMemoryBlock<T>(); 
        }
    }
    public class ValueBuffer<T> : Buffer<T> where T : struct
    {
        public ValueBuffer(**params**) : base(**params**) { }
        
        protected override IMemoryBlock<T> CreateMemoryBlockPreferDisk()
        {
            return new DiskMemoryBlock<T>();
        }
    }
