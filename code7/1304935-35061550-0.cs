    if(e.Row.RowType == DataControlRowType.DataRow)
    {
       string textToReplace = searchDescription.Text;
       string newText = "<b>" +searchDescription.Text + "</b>";
       e.Row.Cells[4].Text =e.Row.Cells[4].Text.Replace(textToReplace, newText);    
    }
