    String s = Convert.ToString(rdr.GetValue(4));
    if(!String.IsNullOrEmpty(s))
    {
       DateTime dt = DateTime.Parse(s);
       lblDate.Text = dt.ToString("MMMM d,yyyy");
    }
