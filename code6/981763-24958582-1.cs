    foreach (string key in rowsDictionary.Keys)
    {
        List<EmployeeSummary> empList = rowsDictionary[key];
        foreach (EmployeeSummary emp in empList)
        {
            string combinedKey = emp.LastName.Trim().ToUpper() +
                emp.FirstName.Trim().ToUpper();
            string delivery_system = emp.Delivery_System;
            List<string> systems = null;
            if (!deliverySystemFinder.TryGetValue(combinedKey, out systems))
            {
                systems = new List<string>();
                deliverySystemFinder[combinedKey] = systems;
            }
            if (!systems.Contains(delivery_system))
                systems.Add(delivery_system);
        }
    }
