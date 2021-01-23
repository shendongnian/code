    var typeA = new Type()
                {
                   Value = "Type A"
                };
    
    var typeB = new Type()
                {
                   Value = "Type B"
                };
    var statuses = new List<Status>(){
                         new Status()
                         {
                             Value = "On",
                             ChildStatuses = new List<Status>(){
                                                   new Status()
                                                   {
                                                      Value = "Success",
                                                      Types = new List<Type>()
                                                              {
                                                                typeA,
                                                                typeB
                                                              }
                                                   },
                                                   new Status()
                                                   {
                                                      Value = "Fail",
                                                      Types = new List<Type>()
                                                              {
                                                                typeB
                                                                
                                                              }
                                                   }
                         }
                       };
    
    
    context.Set<Status>().AddOrUpdate(s => s.Value, statuses.ToArray() );
