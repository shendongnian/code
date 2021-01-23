    List<RepItem> setlist = new List<RepItem>();
     int set = 10;
     for (int i = 1; i <= set; i++ )
          setlist.Add(new RepItem() {Header = "Reps in Set " + i});
     RepList.DataContext = setlist;
