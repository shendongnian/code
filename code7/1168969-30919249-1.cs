         var asyncTasks = new Dictionary<Service, Task>();
		 foreach(var service in services)
         {
            Console.WriteLine("Running " + service.Name);
           asyncTasks.Add(service, client.PostAsync(_baseURL + service.Id.ToString(), null));
         }
		 // All tasks are running, so wait for all of them to finish here
         await Task.WhenAll(asyncTasks);
         foreach(var service in asyncTasks.Keys) {
			Console.WriteLine("Service " + service.Name + " returned " + syncTasks[service].Result);
		 }
