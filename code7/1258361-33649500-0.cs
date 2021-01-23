    private void Form1_Load(object sender, EventArgs e)
    {
        textBox1.Parent = dataGridView1;              // nest the TextBox
        placeControl(dataGridView1, textBox1, 2);     // place it over the 3rd column header
    }
    private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
        placeControl(dataGridView1, button1, 2);
    }
    private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
    {
        placeControl(dataGridView1, button1, 2);
    }
    void placeControl(DataGridView dgv, Control ctl, int index)
    {
        Rectangle R = dgv.GetColumnDisplayRectangle(index, true );  // or false
        ctl.Location = R.Location;
        ctl.Size = new Size(R.Width, dgv.ColumnHeadersHeight);
    }   
