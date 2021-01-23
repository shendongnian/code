    public void  LocateItem(TreeNode item ,TreeNode rootNode)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(rootNode); //push at queue root elem
        bool found = false;
        while(queue.Any()) // while queue has any item (or when we find item)
        {
            var p = queue.Peek(); // get first item from queue
            var children = p.Children; // get the children from item
            if (children.Any())
            {
                for (int i = 0; i < children.Count; i++) 
                {
                    if (children[i].Equals(item))
                    {
                        item.IsExpanded = true;
                        found = true;
                        var parent = item.Parent;
                        int whileCount = 0; //level limit
                        while(whileCount<10000)//this tree very big
                        {                               
                            if (parent != null) //expand all parents too.
                            {
                                parent.IsExpanded = true;
                            }
                            else
                            }
                                break;
                            }
                            parent = parent.Parent;
                            whileCount = whileCount + 1;
                        }
                        break; //we found the element, break.
                    }
                }
            }
            queue.Dequeue(); //remove item from queue
            if (!found)//if not found
            {
                foreach (var ch in children)
                    queue.Enqueue(ch); //push children into queue
            }
        }
    }
