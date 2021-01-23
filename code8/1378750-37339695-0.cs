        for (int i = 0; i < Count; i++)
        {
            TextBox txt = new TextBox();
            TableCell cell = new TableCell();
            txt.ID = "txt" + i.ToString();
            cell.ID = "cell" + i.ToString();
            cell.Controls.Add(txt);
            row.Cells.Add(cell);
        }
