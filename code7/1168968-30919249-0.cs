         var asyncTasks = new List<Task>();
		 foreach(var service in services)
         {
            Console.WriteLine("Running " + service.Name);
           asyncTasks.Add(client.PostAsync(_baseURL + service.Id.ToString(), null));
         }
		 // All tasks are running, so wait for all of them to finish here
         await Task.WhenAll(asyncTasks);
         foreach(var t in asyncTasks) {
			//Do something with t.Result
		 }
