    int days = (endDate - startDate).Days;
    var model = new AttendanceVM(startDate, endDate);
    foreach (var item in result)
    {
      StudentVM student = new StudentVM(days);
      student.Name = item.Name;
      foreach(var value in item.Values)
      {
        int index = (value.Date - startDate).Days;
        student.Attendance[index] = value.Attend;
      }
      model.Students.Add(student);
    }
    return View(model);
    
    
