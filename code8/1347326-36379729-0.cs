    List<string> names = new List<string>()
            {"Steve", "Mark", "Luke", "John", "Robert"};
    BindingList<string> bl1 = new BindingList<string>(names);
    ComboBox_Rank_0.DataSource = bl1;
    
    BindingList<string> bl2 = new BindingList<string>(names);
    ComboBox_Rank_1.DataSource = bl2;
