    List<Rectangle> EntryRects = new List<Rectangle>();
    
    void UpdateDisplayBounds()
    {    
        foreach(gItem gEntry in GanttItems)
        {
            if(gEntry.StartDate <= dispEndDate && gEntry.EndDate >= dispStartDate
               && gEntry.LineNumber >= dispStartItem && gEntry.LineNumber <= dispEndItem)
            {
                int x = (gEntry.StartDate - dispStartDate) * GridSize;
                int y = (gEntry.LineNumber - dispStartItem) * GridSize;
                int width = gEntry.Length * GridSize;
                int height = GridSize;
                EntryRects.Add(new Rectangle(x, y, width, height);
            }
        }    
    }
