    StringBuilder sb = new StringBuilder();
    using(var reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            var question = reader[0].ToString();
            sb.AppendFormat("Q: {0}\n", question); // use any other format if needed
        }
    }
    lbquestion.Content = sb.ToString();
