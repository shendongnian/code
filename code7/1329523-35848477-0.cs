    Page_Load()
    {
      var t1 = GetDataForDropDown1();
      var t2 = GetDataForDropDown2();
      var t3 = GetDataForDropDown3();
      await Task.WhenAll(t1, t2, t3);
      PopulateDD1();
      PopulateDD2();
      PopulateDD3();
    }
    async Task GetDataForDropDown1()
    {
      SqlQuery
      Call To Database Access Layer
      await Execute Stored Procedure
      Store Returned Result In Dataset  
    }
    async Task GetDataForDropDown2()
    {
      SqlQuery
      Call To Database Access Layer
      await Execute Stored Procedure
      Store Returned Result In Dataset  
    }
    async Task GetDataForDropDown3()
    {
      SqlQuery
      Call To Database Access Layer
      await Execute Stored Procedure
      Store Returned Result In Dataset  
    }
