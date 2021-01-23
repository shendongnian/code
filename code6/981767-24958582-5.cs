    foreach (string key in rowsDictionary.Keys)
    {
        List<EmployeeSummary> empList = rowsDictionary[key];
        foreach (EmployeeSummary emp in empList)
        {
            string combinedKey = emp.LastName.Trim().ToUpper() +
                emp.FirstName.Trim().ToUpper();
            string delivery_system = emp.Delivery_System;
            List<string> systems = null;
            // check if the dictionary contains the list
            if (!deliverySystemFinder.TryGetValue(combinedKey, out systems))
            {
                // if not, create it and add it 
                systems = new List<string>();
                deliverySystemFinder[combinedKey] = systems;
            }
            // check if the list contains the value and add it
            if (!systems.Contains(delivery_system))
                systems.Add(delivery_system);
        }
    }
