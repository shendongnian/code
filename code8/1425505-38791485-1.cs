    private int Linesel(List<GraphicsPath> LineGroup)
    {
        int last = LineGroup.Count -1;
        Pen pen = new Pen(Color.Navy, 8);
        return LineGroup[last].IsOutlineVisible(Latest, pen)?last:-1;
    }
