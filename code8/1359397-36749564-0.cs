    public object Clone(IList<Node> ListNotToClone)
        {
            NodetoReturnFiltered = new Node();
            toReturnFiltered.Name = this.Name;
            toReturnFiltered.ID = this.ID;
            toReturnFiltered.ParentNode= this.ParentNode;
            foreach (Node child in this.ComponentNodes)
            {
                if (!ListNotToClone.Contains(child))
                {
                    toReturnFiltered.ComponentNodes.Add((Node)child.Clone(ListNotToClone));
                }
            }
            return toReturnFiltered;
        }
