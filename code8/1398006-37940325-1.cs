    public List<Node> AllWrong(Node root)
    {
        List<Node> wrongs = new List<Node>();
        if (root == null)
            return wrongs;
        if (root.RightNode == null)
        {
            // This is not right
            wrongs.Add(root);
        }
        // Recursively search - assumes this is a tree 
        wrongs.AddRange(AllWrong(root.rightNode));
        wrongs.AddRange(AllWrong(root.bottomNode));
       
        return wrongs;
    }
