    private void Form1_Load(object sender, EventArgs e)
    {
        CheckedListBox chkList = new CheckedListBox();
        chkList.BorderStyle = BorderStyle.None;
        chkList.Margin = new Padding(20, 3, 3, 3);
        chkList.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F" });
        FlowLayoutPanel fPanel = new FlowLayoutPanel();
        fPanel.Height = this.Height;
        chkList.BackColor = fPanel.BackColor = Color.White;
        fPanel.Controls.Add(chkList);
    
        this.Controls.Add(fPanel);
    }
