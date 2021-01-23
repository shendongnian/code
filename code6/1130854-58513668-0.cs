    foreach (MyEnum myenum in(MyEnum[])Enum.GetValues(typeof(MyEnum))){
        Button btn = new Button();
            btn.Name = "This Is Optional";
            btn.Content = "Content";
            btn.Click += CustomCommand;
            btn.CommandParameter = myenum;
            buttonlist.Add(temp);
    }
