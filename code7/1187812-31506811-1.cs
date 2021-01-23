    public List<MyNode> GetPath(Vector2D startPoint, Vector2D endPoint)
        {
            //create the open list of nodes, initially containing only our starting node
            //create the closed list of nodes, initially empty
            List<MyNode> open = new List<MyNode>();
            List<MyNode> closed = new List<MyNode>();
            //Find the starting node
            MyNode start = FindNearestNode(startPoint);
            if (start == null)
                return null;
            //Find the ending node
            MyNode end = FindNearestNode(endPoint);
            if (end == null)
                return null;
            start.G = G(start.Pos, endPoint);
            start.H = H(start.Pos, endPoint);
            open.Add(start);
            while (open.Count != 0)
            {
                //consider the best node in the open list (the node with the lowest f value)
                double d = open.Min(x => x.F);
                MyNode curr = open.First(x => x.F.CompareTo(d) == 0);
                closed.Add(curr);
                open.Remove(curr);
                //If current node is goal              
                if (curr == end)
                {
                    //Loop over the parents to get the path
                    List<MyNode> ns = new List<MyNode>();
                    MyNode n = end;
                    ns.Add(n);
                    while (n != start)
                    {
                        ns.Add(n.parent);
                        n = n.parent;
                    }
                    ns.Reverse();
                    return ns;
                }
                for (int i = 0; i < curr.Edges.Count; i++)
                {
                    MyNode possibleNeigbour = curr.Edges[i].NodeTo();
                    if (closed.Contains(possibleNeigbour))
                    {
                        //ignore it
                    }
                    else if (!open.Contains(possibleNeigbour))
                    {
                        possibleNeigbour.G = G(possibleNeigbour.Pos, endPoint);
                        possibleNeigbour.H = H(possibleNeigbour.Pos, endPoint);
                        possibleNeigbour.parent = curr;
                        open.Add(possibleNeigbour);
                    }
                    else if(open.Contains(possibleNeigbour))
                    {
                        if (possibleNeigbour.G < curr.G)
                        {
                            possibleNeigbour.parent = curr;
                        }
                    }
                }
            }
            
            return null;
        }
