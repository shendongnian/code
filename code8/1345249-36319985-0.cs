    Dictionary<int, MyIEnumerable> MyDictionary = new Dictionary<int, MyIEnumerable>();
    while (dr.Read()) {
        MyIEnumerable PersonEntry = new MyIEnumerable();
        PersonEntry.user_id = Convert.ToInt32(dr[1]);
        PersonEntry.Name = dr[2].ToString();
        PersonEntry.Meals = Convert.ToInt32(dr[3]);
        MyDictionary[Convert.ToInt32(dr[1]))] = PersonEntry;
    }
