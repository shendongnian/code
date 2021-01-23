    string[] theParms = // initialization
    string theQuery = // initialization
    SqlCommand cmd = new SqlCommand(/* enter connection string */, theQuery)
    for(int i = 0; i < theParams.Length; i++)
    {
        int index = cmd.Text.IndexOf("{?}");
        if(index > -1)
        {
            string pName = string.Format("@p{0}", i);
            cmd.Text = cmd.Text.Remove(index, 3).Insert(index, pName);
            cmd.Parameters.Add(new SqlParameter() { Name = pName, Value = theParms[i] });
        }
    }
