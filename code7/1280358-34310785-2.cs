    while (oReader.Read())
    {
        TextBox1.Text = oReader.GetString(1); // 1 is the Parameter that is The zero-based column ordinal you can change it to what you want
        TextBox2.Text = oReader.GetString(2);
    }
