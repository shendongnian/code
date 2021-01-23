    private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
    {
    LinkButton lnkbtn= sender as LinkButton;
    //getting particular row linkbutton
    GridViewRow grow = lnkbtn.NamingContainer as GridViewRow;
    //getting userid of particular row
    string prodid = ProductGrid.DataKeys[gvrow.RowIndex].Value.ToString();
    string prodname = grow.Cells[0].Text;
    }
