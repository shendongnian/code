    List<MyClass> list = new List<MyClass>();
    foreach (DataRow dr in ds.Tables[0].Rows)
    {
      var myObj = new MyClass();
      myObj.MyColumn = dr["MyColumn"];
      .. // and so on all your columns as properties on MyClass
    }
    return  JsonConvert.SerializeObject(list);
