    string nodes = JsonConvert.SerializeObject<Node<Person>>(personNode);
    [JsonObject]
    public class Node<T> : IEqualityComparer, IEnumerable<T>, IEnumerable<Node<T>> {
        [JsonProperty]
        public IEnumerable<Node> Children { get { return _children; } }
        public Node(T value) {
            Value = value;
        }
        public Node<T> this[int index] {
            get {
                return _children[index];
            }
        }
        public Node<T> Add(T value, int index = -1) {
            var childNode = new Node<T>(value);
            Add(childNode, index);
            return childNode;
        }
        public IEnumerable<Node<T>> SelfAndDescendants {
            get {
                return this.ToIEnumarable().Concat(Children.SelectMany(c => c.SelfAndDescendants));
            }
        }
    }
