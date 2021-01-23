c#
using System.Collections.Generic;  
using EnvDTE;  
using EnvDTE80;
public static class SolutionProjects  
{
    public static DTE2 GetActiveIDE()
    {
        // Get an instance of currently running Visual Studio IDE.
        DTE2 dte2 = Package.GetGlobalService(typeof(DTE)) as DTE2;
        return dte2;
    }
    public static IList<Project> Projects()
    {
        Projects projects = GetActiveIDE().Solution.Projects;
        List<Project> list = new List<Project>();
        var item = projects.GetEnumerator();
        while (item.MoveNext())
        {
            var project = item.Current as Project;
            if (project == null)
            {
                continue;
            }
            if (project.Kind == ProjectKinds.vsProjectKindSolutionFolder)
            {
                list.AddRange(GetSolutionFolderProjects(project));
            }
            else
            {
                list.Add(project);
            }
        }
        return list;
    }
    private static IEnumerable<Project> GetSolutionFolderProjects(Project solutionFolder)
    {
        List<Project> list = new List<Project>();
        for (var i = 1; i <= solutionFolder.ProjectItems.Count; i++)
        {
            var subProject = solutionFolder.ProjectItems.Item(i).SubProject;
            if (subProject == null)
            {
                continue;
            }
            // If this is another solution folder, do a recursive call, otherwise add
            if (subProject.Kind == ProjectKinds.vsProjectKindSolutionFolder)
            {
               list.AddRange(GetSolutionFolderProjects(subProject));
            }
           else
           {
               list.Add(subProject);
           }
        }
        return list;
    }
}
