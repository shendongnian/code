    List<ExtendMonkey> monkeyList = new List<ExtendMonkey>();
    for(int i = 0; i < 3; i++)
    {
    monkeyList.Add(new ExtendMonkey("Monkey" + i, "MonkeyNickName" + i));
    }
    GridView1.DataSource = monkeyList;
    GridView1.DataBind();
    GridView1.Columns[2].Visible = false; //this column has age
