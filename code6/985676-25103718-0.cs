    if (e.Row.Cells.Count > 0)
    {
        TableCell cell = e.Row.Cells[0];
        if (cell.Controls.Count > 2)
        {
            LinkButton _singleClickButton = (LinkButton)cell.Controls[2];
            string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "Select$" + e.Row.RowIndex);
            e.Row.Style["cursor"] = "hand";
        }
    }
