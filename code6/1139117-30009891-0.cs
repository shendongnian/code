    private List<Cell> FindPath(Cell A, Cell B)
    {
        var parent = new Dictionary<Cell, Cell>();
    
        List<Cell> queue = new List<Cell>();
        List<Cell> visited = new List<Cell>();
    
        queue.Add(A);
        parent.Add(A, null);
    
        while (queue.Count != 0)
        {
            Cell c = queue[0];
            queue.RemoveAt(0);
    
            visited.Add(c);
    
            if (c == B)
                break;
    
            foreach (Cell near in c.NearCells)
            {                    
                if (!visited.Contains(near))
                {
                    parent.Add(near, c);
                    visited.Add(near);
                    queue.Add(near);
                }
            }
        }
    
        List<Cell> path = new List<Cell>();
                
        if(parent.ContainsKey(B))
        {
            Cell backTrack = B;
            do
            {
                path.Add(backTrack);
                backTrack = parent[backTrack];
            }
            while (backTrack != null);
            path.Reverse();
        }
        return path;
    }
