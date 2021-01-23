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
        wrongs.AddRange(AllWrongs(root.rightNode));
        wrongs.AddRange(AllWrongs(root.bottomNode));
       
        return wrongs;
    }
