    public class Node : IEnumerable<Node>
    {
        public string Name { get; internal set; }
        public string Value { get; internal set; }
 
        public Node Parent { get; internal set; }
        public List<Node> Children { get; internal set; }
        public Node(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"{nameof(Name)}");
            Name = name;
            Children = new List<Node>();
        }
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
        public IEnumerator<Node> GetEnumerator()
        {
            var self = this;
            var queue = new Queue<Node>();
            queue.Enqueue(self);
            while (queue.Any())
            {
                yield return queue.Dequeue();
                foreach (var child in self.Children)
                    queue.Enqueue(child);
            }
        }             
    }
