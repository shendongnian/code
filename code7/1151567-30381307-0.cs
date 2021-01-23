    protected void grid_PreRender(object sender, EventArgs e)
    {
        if (grid.Items.Count > 0)
        {
            //Format first row of grid
            grid.Items[0].BackColor = Color.LightGray;
        }
    }
