    public abstract class Node<TNode, TNodeSupport, TKey, TValue>
        where TNode : Node<TNode, TNodeSupport, TKey, TValue>
        where TNodeSupport : Node<TNode, TNodeSupport, TKey, TValue>.BaseNodeSupport, new()
        where TValue : class
    {
        protected static readonly TNodeSupport Support = new TNodeSupport();
    
        public KeyValuePair<TKey, TValue> KeyValue { get; set; }
        public TNode Next { get; set; }
        public TNode Previous { get; set; }
        protected Node(TValue value)
        {
            this.KeyValue = new KeyValuePair<TKey, TValue>(Support.GetKeyFromValue(value), value);
            Next = null;
            Previous = null;
        }
    
        public class LRUCache
        {
            private readonly int capacity;
            private int count;
            private readonly TNode head;
            private readonly Dictionary<TKey, TNode> myDictionary;
            public LRUCache(int capacity)
            {
                head = Support.CreateHeadNode();
                head.Next = head;
                head.Previous = head;
                this.capacity = capacity;
                myDictionary = new Dictionary<TKey, TNode>();
            }
            public void set(TValue value)
            {
               TKey key = Support.GetKeyFromValue(value);
               TNode node;
               myDictionary.TryGetValue(key, out node);
               if (node == null)
               {
                  if (this.count == this.capacity)
                  {
                        // remove the last element
                       myDictionary.Remove(head.Previous.KeyValue.Key);
                       head.Previous = head.Previous.Previous;
                       head.Previous.Next = head;
                       count--;
                   }
                   // create new node and add to dictionary
                   var newNode = Support.CreateNodeFromValue(value);
                   myDictionary[key] = newNode;
                   this.InsertAfterTheHead(newNode);
                   // increase count
                   count++;
               }
               else
               {
                   node.KeyValue = new KeyValuePair<TKey, TValue>(key, value);
                    this.MoveToFirstElementAfterHead(node);
               }
            }
            public TValue get(TKey key)
            {
                TNode node;
                myDictionary.TryGetValue(key, out node);
                if (node == null)
                {
                    return null;
        
                }
                this.MoveItToFirstElementAfterHead(node);
                return node.KeyValue.Value;
            }
        }
        
        public abstract class BaseNodeSupport
        {
            public abstract TKey GetKeyFromValue(TValue value);
            public abstract TNode CreateNodeFromValue(TValue value);
            public abstract TNode CreateHeadNode();
        }
    
    }
