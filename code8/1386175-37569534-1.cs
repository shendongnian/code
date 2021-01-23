    Employee emp = new Employee(){Name = TextBox1.Text,
                                  Gender= TextBox2.Text,
                                  Salary = float.Parse(TextBox3.Text),
                                  DepartmentId=Convert.ToInt32(DropDownList1.SelectedValue)
                                 }; 
     db.Employees.Add(emp);
     db.SaveChanges();
