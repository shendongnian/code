    public void AddNode(int x, Node root) 
    {
        Node newNode = new Node(x);
        this->AddNode(newNode, root);
    }
    private void AddNode(Node newNode, Node root)
    {
        if (root == null) 
        {
            root = newNode;
        }
        if (root.Value == newNode.Value) 
        {
            return;
        } 
        else if (newNode.Value < root.Value) 
        {
            if (root.Left == null) 
            {
                root.Left = newNode;
            } 
            else 
            {
                AddNode(newNode, root.Left);
            }
        } 
        else if (newNode.Value > root.Value) 
        {
            if (root.Right == null) 
            {
                root.Right = newNode;
            } 
            else 
            {
                AddNode(newNode, root.Right);
            }
        }
    }
