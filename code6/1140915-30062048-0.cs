    public int insert(Node newNode) // return array index of added node
        {
            int? y = null;
            int? x = this.root;
    
            while (x.HasValue)
            {
                y = x;
                if (newNode.key < this.tree[x.Value])
                {
                   //your logic here
                }
    
            }
    
            return 0;
        }
