    public enum MemoryBlockCreationLocation
    {
        Disk,
        Ram
    }
    public interface IMemoryBlockFactory<T>
    {
        IMemoryBlock<T> CreateMemoryBlock(MemoryBlockCreationLocation preferredLocation);
    }
    public class Buffer<T>
    {
        IMemoryBlock<T> buffer;
        public Buffer(**params**, IMemoryBlockFactory<T> memoryBlockFactory)
        {
            var preferredLocation = (**conditions**)
                ? MemoryBlockCreationLocation.Disk
                : MemoryBlockCreationLocation.Ram;
            buffer = memoryBlockFactory.CreateMemoryBlock(preferredLocation);
        }
    }
    public class GeneralMemoryBlockFactory<T> : IMemoryBlockFactory<T>
    {
        public IMemoryBlock<T> CreateMemoryBlock(MemoryBlockCreationLocation preferredLocation)
        {
            // We can't create a DiskMemoryBlock in general - ignore the preferred location and return a RamMemoryBlock.
            return new RamMemoryBlock<T>();
        }
    }
    public class ValueTypeMemoryBlockFactory<T> : IMemoryBlockFactory<T>
        where T : struct
    {
        public IMemoryBlock<T> CreateMemoryBlock(MemoryBlockCreationLocation preferredLocation)
        {
            switch (preferredLocation)
            {
                case MemoryBlockCreationLocation.Ram:
                    return new RamMemoryBlock<T>();
                case MemoryBlockCreationLocation.Disk:
                default:
                    return new DiskMemoryBlock<T>();
            }
        }
    }
