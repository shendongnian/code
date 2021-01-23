    var statuses = new List<Status>(){
                         new Status()
                         {
                             Value = "On",
                             ChildStatuses = new List<Status>(){
                                                   new Status()
                                                   {
                                                      Value = "Success"
                                                   },
                                                   new Status()
                                                   {
                                                      Value = "Fail"
                                                   }
                         }
                       };
    
    
    context.Set<Status>().AddOrUpdate(s => s.Value, statuses.ToArray() );
