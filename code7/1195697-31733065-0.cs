    if (e.Salary > 0)
    {
        vm.Salary = e.Salary.ToString();
    }
    else
    {
         vm.Salary = ModelState["Salary"].Value.AttemptedValue;
    }
