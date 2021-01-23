        protected void MergeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //here you should have a way to identify which rows are you goingo to change
        //I used the text in the first row
        string[] rowsToColor = new[] { "Número de Médicos", "Médicos Visitados" };
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (rowsToColor.Contains(e.Row.Cells[0].Text))
            e.Row.BackColor =  System.Drawing.Color.Blue; //it is just an example color
        }
    }
