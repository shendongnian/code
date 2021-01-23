    var query=context.Modules
                     .Where(m=>m.IsEnabled == 1)
                     .Select(m=> new {  ModuleId= m.Id, 
                                        ModuleScreen=m.ModuleScreen.Where(m=>m.IsEnabled == 1)
                                     }
                            );
