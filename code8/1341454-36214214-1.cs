    int count = myReader.FieldCount;
    while(myReader .Read()) 
    {
        for(int i = 0 ; i < count ; i++) 
        {
            Console.WriteLine(myReader.GetValue(i));
        }
    }
