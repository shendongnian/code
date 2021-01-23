    public class Connection :  BaseVM
    {
        public Connection(string name, Node a, Node b)
        {
            this.Name = name;
            this.NodeA = a;
            this.NodeB = b;
        }
        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                Notify( "Name" );
            }
        }
        Node _nodeA;
        public Node NodeA
        {
            get { return _nodeA; }
            set
            {
                if (_nodeA == value) return;
                _nodeA = value;
                Notify( "NodeA" );
            }
        }
        Node _nodeB;
        public Node NodeB
        {
            get { return _nodeB; }
            set
            {
                if (_nodeB == value) return;
                _nodeB = value;
                Notify( "NodeB" );
            }
        }
