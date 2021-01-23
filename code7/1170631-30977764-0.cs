    // the current list
    var currentList = new List<Employee>();
    currentList.Add(new Employee { Id = 154, Name = "George", Salary = 10000 });
    currentList.Add(new Employee { Id = 233, Name = "Alice", Salary = 10000 });
    // new list
    var newList = new List<Employee>();
    newList.Add(new Employee { Id = 154, Name = "George", Salary = 25000 });
    newList.Add(new Employee { Id = 234, Name = "Bob", Salary = 10000 });
    // clean up
    foreach (var oldEmployee in currentList.ToArray())
        if (!newList.Any(item => oldEmployee.Id == item.Id))
            currentList.Remove(oldEmployee);
    // check if the new item is found within the currentlist. 
    // If so? update it's values else add the object.
    foreach (var newEmployee in newList)
    {
        var oldEmployee = currentList.FirstOrDefault(item => item.Id == newEmployee.Id);
        if (oldEmployee == null)
        {
            // add
            currentList.Add(newEmployee);
        }
        else
        {
            // modify
            oldEmployee.Name = newEmployee.Name;
            oldEmployee.Salary = newEmployee.Salary;
        }
    }
