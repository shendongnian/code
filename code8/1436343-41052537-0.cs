        static private void FindProjectsIn(EnvDTE.ProjectItem item, List<EnvDTE.Project> results)
        {
            if (item.Object is EnvDTE.Project)
            {
                var proj = (EnvDTE.Project)item.Object;
                if (new Guid(proj.Kind) != Utilities.ProjectTypeGuids.Folder)
                {
                    results.Add((EnvDTE.Project)item.Object);
                }
                else
                {
                    foreach (EnvDTE.ProjectItem innerItem in proj.ProjectItems)
                    {
                        FindProjectsIn(innerItem, results);
                    }
                }
            }
            if (item.ProjectItems != null)
            {
                foreach (EnvDTE.ProjectItem innerItem in item.ProjectItems)
                {
                    FindProjectsIn(innerItem, results);
                }
            }
        }
        static private void FindProjectsIn(EnvDTE.UIHierarchyItem item, List<EnvDTE.Project> results)
        {
            if (item.Object is EnvDTE.Project)
            {
                var proj = (EnvDTE.Project)item.Object;
                if (new Guid(proj.Kind) != Utilities.ProjectTypeGuids.Folder)
                {
                    results.Add((EnvDTE.Project)item.Object);
                }
                else
                {
                    foreach (EnvDTE.ProjectItem innerItem in proj.ProjectItems)
                    {
                        FindProjectsIn(innerItem, results);
                    }
                }
            }
            foreach (EnvDTE.UIHierarchyItem innerItem in item.UIHierarchyItems)
            {
                FindProjectsIn(innerItem, results);
            }
        }
        static internal IEnumerable<EnvDTE.Project> GetEnvDTEProjectsInSolution()
        {
            List<EnvDTE.Project> ret = new List<EnvDTE.Project>();
            EnvDTE80.DTE2 dte = (EnvDTE80.DTE2)ServiceProvider.GlobalProvider.GetService(typeof(EnvDTE.DTE));
            EnvDTE.UIHierarchy hierarchy = dte.ToolWindows.SolutionExplorer;
            foreach (EnvDTE.UIHierarchyItem innerItem in hierarchy.UIHierarchyItems)
            {
                FindProjectsIn(innerItem, ret);
            }
            return ret;
        }
