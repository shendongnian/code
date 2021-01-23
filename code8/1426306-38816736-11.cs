        //dataGridView1.DataSource = something;
    }
    void AutoHeightGrid(DataGridView grid)
    {
        var proposedSize = grid.GetPreferredSize(new Size(0, 0));
    dataGridView1.MaximumSize = new Size(this.dataGridView1.Width, 0);
        grid.Height = proposedSize.Height;
    }
    dataGridView1.AutoSize = true;
