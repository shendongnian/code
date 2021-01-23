    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
        {
            listView1.View = View.Details;
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listView1.Columns[0].Width = listView1.ClientSize.Width - 25;
            listView1.Height = 244;
        }
        else
        {
            listView1.View = View.List;
            listView1.Columns[0].Width = 50;
            listView1.Height = 44;
        }
    }
