        int ID = -1;
        //try the conversion in a try-catch block. If conversion fails your site won't trow an error
        try
        {
            ID = ((TextBox)(row.Cells[1].Controls[0])).Text;
        }
        catch
        {
            //error converting to integer, but will continue
        }
        //after that do the validating
        if (ID > 500 && ID < 600)
        {
            dt.Rows[row.DataItemIndex]["ID"] = ID;
        }
        else
        {
            //the input was not correct
        }
