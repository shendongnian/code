    private static Stack<Page> PathToTopRec(Page p, Stack<Page> visited=null )
    {
        visited = visited ?? new Stack<Page>();
        if (visited.Contains(p))
            return visited;
        visited.Push(p);
        if (p.Parent == null)
            return visited;
        return PathToTopRec(p.Parent, visited);
    }
