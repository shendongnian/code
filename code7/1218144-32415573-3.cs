    var query=context.Modules
                     .Where(m=>m.IsEnabled == 1)
                     .Select(m=> new ModuleDTO{ Id= m.Id, 
                                                ModuleScreens=m.ModuleScreen.Where(m=>m.IsEnabled == 1)
                                              }
                            );
