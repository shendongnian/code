    public void AddNodeToList(Node nodeToBeAdded)
        {
            Node temp = null;
            if (start == null)
            {
                start = nodeToBeAdded;
            }
            else
            {
                temp = start;
                while (temp.link != null)
                {
                    temp = temp.link;
                }
                temp.link = nodeToBeAdded;
            }
            nodeToBeAdded.link = null;
        }
     public void CreateList(Node[] nodesToBeAdded)
        {
            foreach (Node item in nodesToBeAdded)
            {
                this.AddNodeToList(item);
            }
        }
