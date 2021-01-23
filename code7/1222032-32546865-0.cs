        private void button6_Click(object sender, EventArgs e)
        {
            //
            // Ex 6 - Adding the department along side the employees first and last name
            //
            labelStatus.Text = "";
            var selectedemployees = employees.AsQueryable<Employee>();
            var selecteddepartment = departments.AsQueryable<Department>();
                                    
            if (selectedemployees.Count() > 0)
            {
                comboBox1.Items.Clear();
                foreach (var emp in selectedemployees) 
                {
                        selecteddepartment = from dep in departments.AsQueryable<Department>()
                                             where dep.Id == emp.DepartmentId
                                             select dep;
                         
                        comboBox1.Items.Add(emp.Firstname + ", " + emp.Lastname + ", " + selecteddepartment.FirstOrDefault().DepartmentName);
                    }
                    comboBox1.Text = "Employee Names and Depts Added!";
                }
               
            }
