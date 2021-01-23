    List<float> getGradients(List<PointF> p)
    {
        List<float> grads = new List<float>();
        for (int i = 0; i < p.Count - 1; i++)
        {
            float dx = p[i + 1].X - p[i].X;
            float dy = p[i + 1].Y - p[i].Y;
            if (dx == 0) grads.Add(dy == 0 ? 0 : dy > 0 ? 
                float.PositiveInfinity : float.NegativeInfinity);
            else grads.Add(dy / dx);
        }
        return grads;
    }
    List<float> getLengths(List<PointF> p)
    {
        List<float> lengs = new List<float>();
        for (int i = 0; i < p.Count - 1; i++)
        {
            float dx = p[i + 1].X - p[i].X;
            float dy = p[i + 1].Y - p[i].Y;
            lengs.Add((float)Math.Sqrt(dy * dy + dx * dx));
        }
        return lengs;
    }
    List<float> getGaps(List<PointF> p, bool horizontal)
    {
        List<float> gaps = new List<float>();
        for (int i = 0; i < p.Count - 1; i++)
        {
            float dx = p[i + 1].X - p[i].X;
            float dy = p[i + 1].Y - p[i].Y;
            gaps.Add(horizontal ? dx : dy);
        }
        return gaps;
    }
    List<int> getSigns(List<float> g)
    {  
        return g.Select(x => x > 0 ? 1 : x == 0 ? 0 : -1).ToList();  
    }
