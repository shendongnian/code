    class Node 
    {
        protected int _num;
        protected string _text;
        public Node(int num, string text)
        {
            _num = num;
            _text = text;
        }
        public virtual Node Clone()
        {
            return new Node(_num, _text);
        }
    }
    class SuperNode : Node
    {
        DateTime _superTime;
        public SuperNode(int num, string text, DateTime time)  :base(num, text)
        {
            _superTime = time;
        }
        public override Node Clone()
        {
            return new SuperNode(_num, _text, _superTime);
        }
    } 
