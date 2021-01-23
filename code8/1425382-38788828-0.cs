    public void LoadData()
    {
      try
      {
        using (var conn = new SQLiteConnection(@"Data Source=C:\Crystal Management\Crystal Management\bin\Debug\Konaku.db;Version=3"))
        {
          conn.Open();
          using (var cmd = new SQLiteCommand("SELECT Username,Password FROM LoginData WHERE Username='@username' AND Password = '@password'", conn))
          {
            cmd.Parameters.AddWithValue("@username", flatTextBox1.Text);
            cmd.Parameters.AddWithValue("@password", flatTextBox2.Text);
            using (var reader = cmd.ExecuteReader())
            {
              var count = 0;
              while (reader.Read())
              {
                count = count + 1;
              }
              if (count == 1)
              {
                Base bs = new Base();
                bs.Show();
                Hide();
              }
              else if (count == 0)
              {
                flatAlertBox1.kind = FlatUI.FlatAlertBox._Kind.Error;
                flatAlertBox1.Text = "data not right";
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
