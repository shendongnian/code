    Dictionary<int, MyIEnumerable> MyDictionary = new Dictionary<int, MyIEnumerable>();
    while (dr.Read()) {
        int myKey = Convert.ToInt32(dr[1]));
        if (MyDictionary.ContainsKey(myKey)) 
	    {
            MyDictionary[myKey].Meals += Convert.ToInt32(dr[3]);
	    }
	    else 
	    {
	        MyIEnumerable PersonEntry = new MyIEnumerable();
            PersonEntry.user_id = Convert.ToInt32(dr[1]);
            PersonEntry.Name = dr[2].ToString();
            PersonEntry.Meals = Convert.ToInt32(dr[3]);
            MyDictionary.Add(myKey), PersonEntry);
	    }
    }
