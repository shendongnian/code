        int ID = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
        if (ID > 500 && ID < 600)
        {
            dt.Rows[row.DataItemIndex]["ID"] = ID;
        }
        else
        {
            //the input was not correct
        }
