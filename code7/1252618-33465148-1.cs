    int i=0;
    while(reader.Read())
    {
        String name = reader.GetString(0);
        btnArray[i].Text = name;
        ++i;
        if(i == btnArray.Length) break; //Jus in case there are more values in reader than in array.
    }
