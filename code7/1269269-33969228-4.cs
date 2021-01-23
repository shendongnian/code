    public void CreateSquare(int size)
    {
        //Remove previously created controls and free resources
        foreach (Control item in this.Controls)
        {
            this.Controls.Remove(item);
            item.Dispose();
        }
        //Create TableLayoutPanel
        var panel = new TableLayoutPanel();
        panel.RowCount = size;
        panel.ColumnCount = size;
        panel.BackColor = Color.Black;
        //Set the equal size for columns and rows
        for (int i = 0; i < size; i++)
        {
            var percent = 100f / (float)size;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
        }
        //Add buttons, if you have your desired output in an array
        //you can set the text of buttons from your array
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                var button = new Button();
                button.BackColor = Color.Lime;
                button.Font = new Font(button.Font.FontFamily, 20, FontStyle.Bold);
                button.FlatStyle = FlatStyle.Flat;
                button.Text = string.Format("{0}", (i) * size + j + 1);
                button.Name = string.Format("Button{0}", button.Text);
                button.Dock = DockStyle.Fill;
                button.Click += b_Click;
                panel.Controls.Add(button, j, i);
            }
        }
        panel.Dock = DockStyle.Fill;
        this.Controls.Add(panel);
    }
