    private void testDateTimeNonValideIntoControls(DateTime date, Control control)
    {
        string convertedDate = date.ToString("dd/MM/yyyy");
        if (string.Equals(convertedDate, "01/01/0001"))
        {
            convertedDate = " --- "; 
        }
        var lbl = control as Label;
        if (lbl != null)
        {
            lbl.Text = convertedDate;
        }
        else
        {
            var td = control as TableCell;
            if (td != null)
            {
                td.Text = convertedDate;
            }
            // [...]
        }
    }
