    private int Linesel(List<GraphicsPath> LineGroup)
    {
        int selectedline = -1;
        Pen pen = new Pen(Color.Navy, 8);
        for (int i =0; i < LineGroup.Count; i++)
        {
            if (LineGroup[i].IsOutlineVisible(Latest, pen))
                selectedline = i;
        }
        return selectedline;
    }
