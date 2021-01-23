    List<Customer> customers = GetCustomers("ACT");
    Task[] tasks = new Task[MaxNumOfConcurrentSaves];
    While(customers.Length > 0)
    {
         for(int i = 0; i < MaxNumOfConcurrentTasks; i++){
                tasks[i] = SaveCustomerData(customers[i]);
                customers[i] = null;
         }
         customers = List.FindAll<Customer>(customers, aCust => !(aCust == null));
         Task.AwaitAll(tasks)
    }
