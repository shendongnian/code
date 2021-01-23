    MgrId = {the EmpNum of the Manager you want to populate the class for}
    
    {Execute SQL command to call CTE that gets a particular manager and all subordinates with Level}
    
    {Populate a DataTable with the results of the SQL Command}
    
    foreach row in TheDataTable
     {
      if EmpNum = MgrId 'this is the manager
        {set the names and EmpNums of the class with the columns from this row}
      else 'this is a subordinate
        {add the EmpNum or Name (whichever you want) to the Employee <List> property of the class}
    }
