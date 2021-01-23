    Student ss = new Student();
    ss.Name = txtname.Text;
    ss.Family = txtFamily.Text;
    // insert from listbox to list
     ss.GradeList = new List<double>();
    foreach (double strCol in lstGrade.Items)
    {
   
     ss.GradeList.add(strCol);
    }
