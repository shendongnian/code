    protected System.Drawing.Color SetBackGroundColor(object item)
    {
        DateTime dueDate;
        var bg = System.Drawing.Color.White;
        if (item != null && DateTime.TryParse(item.ToString(), out dueDate))
        {
            if (dueDate < DateTime.Today)
            {
                bg = System.Drawing.Color.Red;
            }
        }
        return bg;
    }
