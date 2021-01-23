    private void sreachbtn_Click(object sender, EventArgs e) 
    {
        //// Need Some Thing Here
        
        int employeeid;
        
        if(int.TryParse(textbo1.Text, out employeeid)) // use your textbox name.
        {
            var found = employee.FirstOrDefault(e=>e.EmployeeIDNum == employeeid);
    
            if(found != null)
            {
                // logic here.
                found.employeeInformationToString()
            }
        }
        
    }
