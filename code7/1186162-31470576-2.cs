     public void  LocateItem(TreeNode item ,TreeNode rootNode)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(rootNode); //push at queue root elem
            bool isFind = false;
            while(queue.Any())// while queue has any item (or when we find item)
            {
                var p = queue.Peek();// get first item from queue
                var childs = p.Childs;// get the childs from item
                if (childs.Any())
                {
                    for (int i = 0; i < childs.Count; i++) 
                    {
                        if (childs[i].Equals(item))
                        {
                            item.IsExpanded = true;
                            isFind = true;
                            var parent = item.Parent;
                            int whileCount = 0; //level limit
                            while(whileCount<10000)//this tree very big
                            {                               
                                if (parent != null) //expand all parents too.
                                    parent.IsExpanded = true;
                                else
                                    break;
                                parent = parent.Parent;
                                whileCount = whileCount + 1;
                            }
                            break;//we find elem,break.
                        }
                    }
                }
                queue.Dequeue();//remove item from queue
                if (!isFind)//if not found
                {
                    foreach (var ch in childs)
                        queue.Enqueue(ch);//push childs into queue
                }
            }
        }
