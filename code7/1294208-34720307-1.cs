    Public void Save(Employee e)
    {
     using (var context = new SchoolManagementDataContext())
       {
          if(e.id != null)  //For Update Part
          {
             var data=context.Employee.FirstorDefault(x=>x.EmployeeId==e.eid);
             data.Employeename=e.name;
             //rest other fileds to update.
             context.Employee.UpdateOnSubmit();
             context.SubmitChanges();
          }
          else
          {
             context.Employee.InsertonSubmit(e);
             context.SubmitChanges();
          }
       }
    }
