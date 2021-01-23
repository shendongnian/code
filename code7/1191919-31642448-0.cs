    private Label createBlock()          <---- for convenience!
    {
        try
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Location = Control.MousePosition;
            label.Size = new Size(89, 36);
            label.BackColor = Color.DarkOliveGreen;
            label.ForeColor = Color.White;
            label.FlatStyle = FlatStyle.Flat;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = "New Block";
            label.ContextMenuStrip = contextBlock;
            canvas.Controls.Add(label);
            MoveBlock(label);
            return label;                <---- for convenience!
        } catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return null;
    }
