    var item = employees.SingleOrDefault(a => a.EmployeeNumber == 20000);
    string s = "";
    if(item!= null)
    {
        s = item.FirstName;
        // your logic ... 
    }
