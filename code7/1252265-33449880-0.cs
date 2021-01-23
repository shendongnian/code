    List<Attendance> lst = new List<Attendance>();
    try
    {
      ....
      ....
      while (dr.Read())
      {
         lst.Add(new Attendance()
         {
            ....
         }
      }
      ...
      ...
      lstvAttendance.ItemsSource = lst;
    }
    catch
    {
      ....
    }
