    DataSet ds = Lookups.Employee.GetEmployee(Company.Current.CompanyID, JobID);
    int MainCount = 1;
    foreach (DataTable table in ds.Tables)
    {
      foreach (DataRow dr in table.Rows)
      {
         ulPODS.Controls.Add(GetLi("<a href=\"#DriverLicence-" + MainCount + "\">Driver Licence-" + ds.Tables[0].Rows[0]["ID"].ToString() + "</a>"));
         Employee emp = GetEmployeeFromDataSet(ds);
         tabsPOD.Controls.Add(GetDivDriverLicence(MainCount, emp));
         MainCount++;
      }
    }
...
    Employee GetEmployeeFromDataSet(DataSet ds) {
      Employee emp = new Employee();
      // convert the data from the ds into the newly made emp.
      return emp;
    }
