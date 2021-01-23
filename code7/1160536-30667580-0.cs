    conn.Open();
    using(SqlTransaction tran = conn.BeginTransaction("Adjustment");
    {
        SqlCommand sqlcmd1 = new SqlCommand("INSERT INTO adjustment_header values('"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"','"+TextBox4.Text+"')",conn);
        sqlcmd1.ExecuteNonQuery();
   
        //adjustment grid row 1
        if (itemno1.SelectedItem.Text != "please select")
        {
            SqlCommand cmd1 = new SqlCommand("INSERT INTO adjustment_grid values('"+TextBox1.Text+"','" + itemno1.SelectedItem.Text + "','" + adj1.SelectedItem.Text + "','" + store1.SelectedItem.Text + "','" + qty1.Text + "','" + cost1.Text + "')", conn);
            cmd1.ExecuteNonQuery();
        }
        //adjustment grid row 2
        if (itemno2.SelectedItem.Text != "please select")
        {
            SqlCommand cmd2 = new SqlCommand("INSERT INTO adjustment_grid values('" + TextBox1.Text + "','" + itemno2.SelectedItem.Text + "','" + adj2.SelectedItem.Text + "','" + store2.SelectedItem.Text + "','" + qty2.Text + "','" + cost2.Text + "')", conn);
            cmd2.ExecuteNonQuery();
        }
        //adjustment grid row 3
        if (itemno3.SelectedItem.Text != "please select")
        {
            SqlCommand cmd3 = new SqlCommand("INSERT INTO adjustment_grid values('" + TextBox1.Text + "','" + itemno3.SelectedItem.Text + "','" + adj3.SelectedItem.Text + "','" + store3.SelectedItem.Text + "','" + qty3.Text + "','" + cost3.Text + "')", conn);
            cmd3.ExecuteNonQuery();
        }
        tran.Commit();
    }
