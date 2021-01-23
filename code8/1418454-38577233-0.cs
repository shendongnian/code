    if(strDeviceType == "Blade")
    {
      using (MyDataContext dc = new MyDataContext())
    {
        var result = from test in dc.Tests
                     join blade in dc.Blades on test.DeviceID equals blade.ID
                     select new { test.ID, blade.Name };
    }
    }
    else
    {
      using (MyDataContext dc = new MyDataContext())
    {
        var result = from test in dc.Tests
                     join engine in dc.Engine on test.DeviceID equals engine.ID
                     select new { test.ID, engine.Name };
    }
    }
