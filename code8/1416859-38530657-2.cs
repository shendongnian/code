    private void btnFilter_Click(object sender, EventArgs e)
    {
        dataGridView1.DataSource = Game.Where(l => l.ServerLocation.ToUpper() == txtLocationFlt.Text.ToUpper() 
                                                && l.GameName.ToUpper() == txtGameFlt.Text.ToUpper()).ToList();
    }
