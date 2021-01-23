           protected void Button1_Click(object sender, EventArgs e)
           {
            Employee emp = new Employee(){
            Name =  TextBox1.Text,
            Gender=  TextBox2.Text,
            Salary = float.Parse(TextBox3.Text),
              Department = new Department() 
               {
                   Name = db.Department.Where(s => s.Id == dropDownList1.SelectValue).Select(i.Name).FirstOrDefault();
               
               },
           };
           db.Employees.Add();
           db.SaveChanges();
           }
