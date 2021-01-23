    void gridView1_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e) {
        if (e.Column == null) return;
        if (e.Column == colGrowth) //condition to paint specific column
        {
            e.Appearance.BackColor = Color.Red;
            e.Handled = true; // must set flag to true to tell grid that it has been customized.
        }
    }
