    gridView1.CustomDrawColumnHeader += 
        new ColumnHeaderCustomDrawEventHandler(gridView1_CustomDrawColumnHeader);
    
    void gridView1_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e) 
    {
        if (e.Column == _yourColumn)
        {
            e.Appearance.BackColor = Color.Red;
            e.Handled = true;
        }
    }
