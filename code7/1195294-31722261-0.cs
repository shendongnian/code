     private void rich1_SelectionChanged(object sender, EventArgs e)
        {
            rich2.SelectionLength = rich1.SelectionLength;
            rich2.SelectionStart = rich1.SelectionStart;
        }
    private void button2_Click(object sender, EventArgs e)
        {
            rich2.SelectedRtf = @"{\rtf1\ansi{colour=12}" + rich2.SelectedRtf;
            rich1.ForeColor = Color.Blue;
        }
