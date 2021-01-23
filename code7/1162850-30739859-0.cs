    private void radMenuItem3_Click(object sender, EventArgs e)
    {
        for (var i = rpvRecord.Controls -1; i >= 0; i --)
        {
            ctrl = rpvRecord.Controls[i];
            rpvRecord.Controls.Remove(cntrl);
            ctrl.Dispose();
        }
    }
