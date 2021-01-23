    private void sreachbtn_Click(object sender, EventArgs e) 
    {
        //// Need Some Thing Here
        
        int employeeid;
        
        if(int.TryParse(textbo1.Text, out employeeid))
        {
            Employee found= null;
            
            foreach(var emp in employee)
            {
                if(EmployeeIDNum == employeeid)
                {
                    found = emp;
                    break;
                }
            }
            
            //var found = employee.FirstOrDefault(e=>e.EmployeeIDNum == employeeid);
    
            if(found != null)
            {
                // logic here.
                found.employeeInformationToString()
            }
        }
    }
