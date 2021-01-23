    buttonclick()// this must be ur edit button
    {
        Button btn= (Button)sender;
        GridViewRow grv = (GridViewRow)btn.NamingContainer;
        string name= grv.Cells[0].Text;
    // once update your updated panel if it wont trigger any value, just like
        UpdatePanel1.Update();
    }
