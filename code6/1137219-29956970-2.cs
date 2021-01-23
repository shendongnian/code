    public void Insert(T item)
    {
        // If this quad doesn't intersect the items rectangle, do nothing
        if (!m_rect.IntersectsWith(item.Rect))
            return;
    }
