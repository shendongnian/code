    public void BindMyDataList()
    {
        myDataList.DataSource = GetData();
        myDataList.DataBind();
        int count = GetData().Rows.Count; //Fetch the count
        myDataList.RepeatColumns = count < 4 ? count : 4;
    }
