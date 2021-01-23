    void DFS(G<V,E> g, V v, Set<V> visited)
    {
        if (visited.Contains(v))
            return;
        visited.Add(v);
        // do something interesting here?
        foreach (w in g.getEdges(v))
            DFS(g, w, visited);
        // uncomment this to allow visiting vertices more than once, and just avoid cycles.
        // visited.Remove(v);
    }
