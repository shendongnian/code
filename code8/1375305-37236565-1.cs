    var _database = new List<Task>
    			{
    				new Task
    				{
    					Customer_Task = new List<Customer_Task>
    					{
    						new Customer_Task
    						{
    							Customer = new Customer {Id = 1, Name = "a"},
    							Task = new Task {Id = 1, Number = 1}
    						},
    						new Customer_Task
    						{
    							Customer = new Customer {Id = 1, Name = "b"},
    							Task = new Task {Id = 1, Number = 1}
    						},
    						new Customer_Task
    						{
    							Customer = new Customer {Id = 2, Name = "a"},
    							Task = new Task {Id = 2, Number = 2}
    						},
    						new Customer_Task
    						{
    							Customer = new Customer {Id = 2, Name = "b"},
    							Task = new Task {Id = 2, Number = 2}
    						}
    					},
    				}
    			};
    			var tasks = _database.SelectMany(t => t.Customer_Task.Select(c => new { Task = c.Task.Id, Name =c.Customer.Name})).ToList();
    			foreach (var t in tasks)
    			{
    				Console.WriteLine(t.Task + " "+t.Name);
    			}
    			Console.ReadLine();
