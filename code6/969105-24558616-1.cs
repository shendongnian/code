    public bool AddMachineToRepairsList(string option)
    {
        string addToRepairs = "";
        if (addToRepairs == "yes")
        {
            int cost = 0;
            int hoursWorked = 0;
    
            var machine = new Repair(cost, hoursWorked);
            Repairs.Add(machine);
            Console.WriteLine("Machine successfully added!");
            return true;
        }
        else
        {
            return false;
        }
    
    }
