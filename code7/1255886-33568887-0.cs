    void Main()
    {
      ExcelPackage pck = new ExcelPackage();
      List<Person> people = new List<Person> {
        new Person { UserName="Cetin", Address1="A1", Telephone="012345"},
        new Person { UserName="Timbo", Address1="A2", Telephone="023456"},
        new Person { UserName="StackO", Address1="A3", Telephone="0 345 6789 01 23"},
      };
    
    
      var wsEnum = pck.Workbook.Worksheets.Add("MyPeople");
    
      //Load the collection starting from cell A1...
      wsEnum.Cells["A1"].LoadFromCollection(people, true, TableStyles.Medium9);
      wsEnum.Cells[wsEnum.Dimension.Address].AutoFitColumns();
      //...and save
      var fi = new FileInfo(@"d:\temp\People.xlsx");
      if (fi.Exists)
      {
        fi.Delete();
      }
      pck.SaveAs(fi);
    }
    
    class Person
    {
      public string UserName { get; set; }
      public string Address1 { get; set; }
      public string Telephone { get; set; }
    }
