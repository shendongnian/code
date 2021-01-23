    public class MyQueue
    {
        private Queue<IFile> _queue;
        private HashSet<int> hashes;
    
        public void Add(IFile file)
        {
            var hash = GetHash(file);
            if (hashes.Add(hash))
            {
                _queue.Enqueue(file);
            }
        }
    }
