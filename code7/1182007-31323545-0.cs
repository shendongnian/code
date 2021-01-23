    private void button1_Click(object sender, EventArgs e)
    {
    	SqlCeConnection con=new SqlCnConnection("Data Source = MyDatabase.sdf; Password ='<pwd>'");
        SqlCeCommand cm = new SqlCeCommand("INSERT INTO albums_tbl(album_name) VALUES (@album_name) ", cn);
        cm.Parameters.Add(new SqlCeParameter(@album_name, textBox1.Text));
    	con.Open();
        cm.ExecuteNonQuery();
    }
