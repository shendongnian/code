       var tasks = new List<Task<string>>();
       foreach (var item in items)
       {
             var closure = item;
             var task =
                 Task.Factory.StartNew(
                      async () =>
                       {
                          try
                          {
                              return await GenerateXml(closure);
                          }
                          catch (Exception exception)
                          {
                                  //log
                                  return "";
                          }
                      }).Unwrap();
             tasks.Add(task);
         }
         Task.WaitAll(tasks.ToArray());
