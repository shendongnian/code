    int sum = 0,sbstract=0;
    for (int i = 0; i < GridView1.Rows.Count; i++)
    {
       if(GridView1.Rows[i].Cells[3].Value == "Credit")
       {
           sum += Convert.ToInt32(GridView1.Rows[i].Cells[2].Value);//Change Cells[2] to Amount's Cell
       }
       else if(GridView1.Rows[i].Cells[3].Value == "Debit")
       {
           sbstract -= Convert.ToInt32(GridView1.Rows[i].Cells[2].Value);//Change Cells[2] to Amount's Cell
       }
    }
    TextBox1.Text = sum.ToString();
    TextBox2.Text = sbstract.ToString();
