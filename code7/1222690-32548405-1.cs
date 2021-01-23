    int sum = 0;
    for (int i = 0; i < GridView1.Rows.Count; i++)
    {
       sum += Convert.ToInt32(GridView1.Rows[i].Cells[2].Value);//Change Cells[2] to Amount's Cell
    }
    TextBox1.Text = sum.ToString();
