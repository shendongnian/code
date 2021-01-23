    info PersonInfo = new Info()
    {
        Text = Username;
        SubItems = new List<string>()
        {
            Password,
            Points.ToString();
            Level.ToString();
        }
    }
    ListView1.Items.Add(ParsonInfo.ToString());
