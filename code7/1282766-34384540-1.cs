    public void BFSDegree(Graph g, string s, string p)
    {
        Queue<string> q = new Queue<string>();
        HashMap<string, int> path_counts = new HashMap<string, int>();
        path_counts.put(s, 1);       
        q.Enqueue(s);
        while (q.size()>0)
        {
            HashMap<string, int> adj_nodes = new HashMap<string, int>();
            foreach (string j in q) 
            {
                foreach (string h in g.adjacentTo(j))
                {
                    if (!path_counts.ContainsKey(h))
                    {
                        int count = 0;
                        if (adj_nodes.containsKey(h))
                            count=adj_nodes.get(h);
                        count += path_counts.get(j);
                        adj_nodes.put(h, count);
                    }
                }
            }
            if (adj_nodes.containsKey(p))
            {
                Console.WriteLine("               " + adj_nodes.get(p));
                return;
            }
            path_counts.putAll(adj_nodes);
            q.clear();
            q.addAll(adj_nodes.keySet());
        }
    }
