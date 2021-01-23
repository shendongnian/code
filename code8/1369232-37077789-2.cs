    namespace Utilities
    {
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.Shell;
    static class DteExtensions
    {
        private static Dictionary<string, Project> CachedProjectsFromPath = new Dictionary<string, Project>();
        private static IEnumerable<Project> _projects;
        private static DTE2 _dte;
        static DteExtensions()
        {
            if (DTE == null) return;
            DTE.Events.SolutionEvents.ProjectRemoved += delegate { _projects = null; };
            DTE.Events.SolutionEvents.ProjectRenamed += delegate { _projects = null; };
            DTE.Events.SolutionEvents.ProjectAdded += delegate { _projects = null; };
        }
        internal static DTE2 DTE => _dte ?? (_dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE2);
        internal static string SolutionName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(DTE.Solution.FullName);
            }
        }
        internal static string SolutionFullPath
        {
            get
            {
                return Path.GetFullPath(DTE.Solution.FullName);
            }
        }
        internal static string SolutionPath
        {
            get
            {
                var path = DTE?.Solution?.FullName;
                return path.IsEmpty() ? string.Empty : Path.GetDirectoryName(path);
            }
        }
        internal static IEnumerable<Project> Projects => _projects ?? (_projects = DTE.Solution.Projects.OfType<Project>().SelectMany(GetProjects));
        internal static string CurrentProjectName => DTE?.ActiveDocument?.ProjectItem?.ContainingProject?.Name;
        internal static Project GetProjectFromFilePath(string filePath)
        {
            if (CachedProjectsFromPath.ContainsKey(filePath))
                return CachedProjectsFromPath[filePath];
            var project = Projects.ToDictionary(p => p, p => (filePath.IndexOf(Path.GetDirectoryName(p.FullName)) >= 0) ? Path.GetDirectoryName(p.FullName).Length : 0)
                .Aggregate((i1, i2) => i1.Value > i2.Value ? i1 : i2);
            CachedProjectsFromPath.Add(filePath, project.Key);
            return project.Key;
        }
        private static IEnumerable<Project> GetProjects(Project projectItem)
        {
            var projects = new List<Project>();
            if (projectItem == null)
                return projects;
            try
            {
                // Project
                var projectFileName = projectItem.FileName;
                if (projectFileName.HasValue() && File.Exists(projectFileName))
                {
                    projects.Add(projectItem);
                }
                else
                {
                    // Folder
                    for (int i = 1; i <= projectItem.ProjectItems.Count; i++)
                    {
                        foreach (var item in GetProjects(projectItem.ProjectItems.Item(i).Object as Project))
                        {
                            projects.Add(item);
                        }
                    }
                }
            }
            catch
            {
                //No logging is needed
            }
            return projects;
        }
    }
