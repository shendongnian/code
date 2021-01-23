                    ProjContext.Load(PublishedProject.Tasks);
                    ProjContext.Load(PublishedProject.Tasks, t => t.Include(pt => pt.Id, pt => pt.Parent));
                    ProjContext.ExecuteQuery();
                    foreach (PublishedTask Task in PublishedProject.Tasks)
                    {
                        string sParentId = null;
                        string sParentName = null;
                        if (!IsNull(Task.Parent))
                        {
                            sParentId = Task.Parent.Id.ToString();
                            sParentName = Task.Parent.Name;
                            string sMyName = Task.Name;
                        }
                        Console.WriteLine("{0}, {1}, {2}, {3}", Task.Name, sParentId, sParentName, Task.Work);
                    }
