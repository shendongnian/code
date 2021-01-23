    public void BindMonth()
    {
        List<Month> listOfMonth = new List<Month>();
        Month fakeMonth = new Month();
          // you need to see your own 
          //code and try to make a fake month with these parameters you want
        fakeMonth.StartMonthName = "Select Start Month";
        fakeMonth.MonthId = 0;
        listOfmounth.Add(fakeMonth);
        foreach(Month m in objUIHelpers.GetAllMonths())
        {
           listOfMonth.Add(m)
        }
        ddlStartMonth.DataSource = listOfMonth;
        ddlStartMonth.DataTextField = "StartMonthName";
        ddlStartMonth.DataValueField = "MonthId";
        ddlStartMonth.DataBind();
        ddlStartMonth.Items.Insert(0, "Select Start Month");}
    }
