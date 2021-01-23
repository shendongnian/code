    public class FileItem
    {
        //Some properties
    }
    public interface IFileEnumerator : IEnumerable<FileItem>
    {
        IFileEnumerator Where(Func<FileItem, bool> predicate);
    }
    public class FileEnumerator : IFileEnumerator
    {
        private readonly string fileName;
        public FileEnumerator(string fileName)
        {
            this.fileName = fileName;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<FileItem> GetEnumerator()
        {
            var items = new List<FileItem>();
            //Read from file and add lines to items
            return items.GetEnumerator();
        }
        public IFileEnumerator Where(Func<FileItem, bool> predicate)
        {
            return new MemoryEnumerator(ToEnumerable(GetEnumerator()).Where(predicate));
        }
        private static IEnumerable<T> ToEnumerable<T>(IEnumerator<T> enumerator) 
        {
            while (enumerator.MoveNext()) 
            {
                yield return enumerator.Current;
            }
        }
    }
    public class MemoryEnumerator : IFileEnumerator
    {
        private readonly IEnumerable<FileItem> items;
        public MemoryEnumerator(IEnumerable<FileItem> items)
        {
            this.items = items;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<FileItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        public IFileEnumerator Where(Func<FileItem, bool> predicate)
        {
            return new MemoryEnumerator(items.Where(predicate));
        }
    }
