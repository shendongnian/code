    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < coin.Count(); i++)
    {
        builder.Append("/");
        builder.Append(coin[i].ToString());
    }
    groupBox1.Text = builder.ToString();
