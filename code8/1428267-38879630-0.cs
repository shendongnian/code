    FData FD = new FData();
    private void dataToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //...
        FD.Show();
    }
    private void btnSearch_Click(object sender, EventArgs e)
    {
        //...
        FD.dgvData.DataSource = ds.Tables[0].DefaultView;
    }
