     Dictionary<string, Action> actions = new Dictionary<string, Action>()
     {
       {"RegularUser", new Action(() => { Employees.AddRange(spc.GetEmployeeInfo(Models.PhoneNumbers.OfficeDepartmentEmployee));})},
       {"DeliveryManager", new Action(() => {Employees.AddRange(spc.GetEmployeeInfo(Models.PhoneNumbers.OfficeDepartmentEmployee));})},                
       {"OfficeDirector", new Action(() => {Employees.AddRange(spc.GetEmployeeInfo(Models.PhoneNumbers.OfficeEmployee));})},
       {"Admin", new Action(() => {Employees.AddRange(spc.GetEmployeeInfo(Models.PhoneNumbers.AllEmployee));})}
    };
      foreach (var position in listPositions)
      {
          if (actions.ContainsKey(position))
          {
             actions[position]();
          }
      }
      rptEmployees.DataSource = Employees;
      rptEmployees.DataBind();
     
