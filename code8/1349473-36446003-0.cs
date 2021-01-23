    ObservableCollection<string> fooColl = new ObservableCollection<string>();
    fooColl.Add("Bill");
    fooColl.Add("Ada");
    fooColl.Add("Jon");
    fooColl.Add("Ben");
    fooColl.Add("Joseph");
    fooColl = new ObservableCollection<string>(fooColl.OrderBy(x => x));
