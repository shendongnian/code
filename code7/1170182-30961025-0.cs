      try
       {
         SqlConnection con3 = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=db-ub;Integrated Security=True");
         con3.Open();
         SqlCommand cmd2 = new SqlCommand(@"SELECT Count(*) FROM Visitors WHERE Id=@id",con3);
        cmd2.Parameters.AddWithValue("@id", textBox_VIex.Text);
        SqlCommand cmd3 = new SqlCommand("UPDATE Visitors SET Day_Out=@dO,Time_Out=@tO WHERE Id=@id", con3);
        cmd3.Parameters.AddWithValue("@id", int.Parse(textBox_VIex.Text));
        cmd3.Parameters.AddWithValue("@dO", DateTime.Now);
        cmd3.Parameters.AddWithValue("@tO", DateTime.Now);
        int o = cmd3.ExecuteNonQuery();
        if(o > 0)
           MessageBox.Show("Good Bye!");
        else
          MessageBox.Show("Error!");
          this.Close();
          FormCheck f2 = new FormCheck();
          f2.Show();
       }
       catch
       {
        MessageBox.Show("Error!");
        textBox_VIex.Clear();
       }
