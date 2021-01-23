    public void Chacked_Changed(object sender, EventArgs e)
    {
    GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent);
    string id = grd1.DataKeys[Row.RowIndex].Value.ToString();
    string cellvalue = Row.Cells[1].Text;
    }
