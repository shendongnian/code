		    int i = 0;
                    int j;
                    while (i < count)
                    {
                        j = 0;
                        tasks = new Task<List<MyBusinessObject>>[nbrOfTasks];
                        foreach (var p in Mycollection.Skip(i).Take(nbrOfTasks))
                        {
                            MyRequestDto dto = new MyRequestDto ();
	                    --Some Proerty Assignment
                            tasks[j] = Task<List<MyBusinessObject>>.Factory.StartNew(MyDelegate, dto);
                            i++;
                            j++;
                        }
 			try
                        {
                            // Wait for all the tasks to finish. 
                            if (tasks != null && tasks.Count() > 0)
                            {
                                tasks = tasks.Where(t => t != null).ToArray();
                                Task.WaitAll(tasks);
                            }
                        }
			catch (AggregateException e)
                        {
		        }		
