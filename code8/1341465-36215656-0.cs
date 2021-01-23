    private void button1_Click(object sender, EventArgs e)
    {
        // we can select tab by tab name
        tabControl1.SelectTab("tabPage2");
        tabControl1.SelectedIndex = 1;
        tabControl1.TabPages[0].Hide();
        tabControl1.TabPages[1].Show();
    }
 
