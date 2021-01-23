    private void radMenuItem3_Click(object sender, EventArgs e)
    {
        while (rpvRecord.Controls.Count > 0)
        {
            rpvRecord.Controls[0].Dispose();
        }
    }
