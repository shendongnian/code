     VCLinkerTool linker;
     foreach (EnvDTE.Project p in VS2015Instance.Solution.Projects)
     {
         if (p.UniqueName.Contains(project.Name))
         {
             var prj = (VCProject)p.Object;
             var cfgs = (IVCCollection)prj.Configurations;
             foreach (VCConfiguration cfg in cfgs)
             {
                 if (cfg.ConfigurationName.Contains("Debug"))
                 {
                    var tools = (IVCCollection)cfg.Tools;
                    foreach (var tool in tools)
                    {
                        if (tool is VCLinkerTool)
                        {
                            linker = (VCLinkerTool)tool;
                            // now I can use linker to set its options.
                            break;
                         }
                    }
                    break;
                  }
              }
              break;
         }
    }
