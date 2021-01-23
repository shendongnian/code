    //create a class
    public class Employee
    {
        string Name {get;set;}
        decimal GrossPay {get;set;}
        decimal NetPay {get;set;}
        //etc...
    }
    //Create an instance of employee
    private void btnCalculate_Click(object sender, EventArgs e)
    {
        Employee tempEmployee = new Employee();
        tempEmployee.Name = txtName.Text;
        tempEmployee.GrossPay = gross_pay;
        tempEmployee.NetPay = net_pay;
        EmployeeList.Add(tempEmployee);
        
    }
    //Get totals from List<Employees>
    private void btnSummary_Click(object sender, EventArgs e)
    {
        Employee TotalEmployee = new Employee();
        for (int i = 0; i < EmployeeList.Count; i++
        {
            TotalEmployee.GrossPay += EmployeeList[i].GrossPay;
            TotalEmployee.NetPay += EmployeeList[i].NetPay;
        }
    }
