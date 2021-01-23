    public void CreateSquare(int size)
    {
        //Remove previously created controls
        foreach (Control item in this.Controls)
        {
            this.Controls.Remove(item);
            item.Dispose();
        }
        var panel = new TableLayoutPanel();
        panel.RowCount = size;
        panel.ColumnCount = size;
        //Set equal size for columns as rows
        for (int i = 0; i < size; i++)
        {
            var percent = 100f / (float)size;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
        }
        //Add buttons
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                var button = new Button();
                button.Text = string.Format("{0}", (i) * size + j + 1);
                button.Name = string.Format("Button{0}", button.Text);
                button.Dock = DockStyle.Fill;
                button.Click += button_Click;
                panel.Controls.Add(button, j, i);
            }
        }
        panel.Dock = DockStyle.Fill;
        this.Controls.Add(panel);
    }
