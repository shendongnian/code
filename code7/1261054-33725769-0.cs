       private void Form1_Load(object sender, EventArgs e)
        {
            TableLayoutPanel brickGrid = new TableLayoutPanel();
            brickGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            brickGrid.SetAutoScrollMargin(2, 2);
            brickGrid.BringToFront();
            brickGrid.BackColor = Color.Red;
            panel1.Controls.Add(brickGrid);
        }
