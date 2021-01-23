    /// <summary>
    /// Queries for all projects in solution, recursively (without recursion)
    /// </summary>
    /// <param name="sln">Solution</param>
    /// <returns>List of projects</returns>
    static List<Project> GetProjects(Solution sln)
    {
        List<Project> list = new List<Project>();
        list.AddRange(sln.Projects.Cast<Project>());
        for (int i = 0; i < list.Count; i++)
            // OfType will ignore null's.
            list.AddRange(list[i].ProjectItems.Cast<ProjectItem>().Select(x => x.SubProject).OfType<Project>());
        return list;
    }
