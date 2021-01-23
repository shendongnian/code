    public void makeDataGridView(int num)
    {
        for (int i = 0; i < num; i++)
        {
            DataGridView[] dgv = new DataGridView[num];
            dgv[i] = new DataGridView();
            dgv[i].Name = "dgv" + i.ToString();
            dgv[i].MouseDown += onMouseDown;
            tableLayoutPanel1.Controls.Add(dgv[i]);
        }
    }
    private void onMouseDown(object sender, MouseEventArgs e)
    {
        //var dgv = sender as DataGridView;
        if (e.Button == MouseButtons.Right)
        {
           //perform task ...
        }
    }
