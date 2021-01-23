           protected void Button1_Click(object sender, EventArgs e)
           {
            Employee emp = new Employee(){
            Name =  TextBox1.Text,
            Gender=  TextBox2.Text,
            Salary = float.Parse(TextBox3.Text),
              Department = new Department() 
               {
                   Name = dropDownList1.SelectValue
               
               },
           };
           db.Employees.Add();
           db.SaveChanges();
           }
