	private ListView generateEmptyClone(ListView toClone)
    {
        ListView newCopy = new ListView();
        newCopy.Alignment = ListViewAlignment.Top;
        newCopy.BorderStyle = BorderStyle.Fixed3D;
        newCopy.BackgroundImageTiled = false;
        newCopy.Font = new Font("Mircosoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, (byte)(0));
        newCopy.ForeColor = SystemColors.MenuText;
        // etc...
        foreach (ColumnHeader head in toClone.Columns)
        {
            newCopy.Columns.Add((ColumnHeader)head.Clone());
        }
        return newCopy;
    }
