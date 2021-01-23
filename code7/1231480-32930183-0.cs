    public class Metadata
    {
        public List<Namespace> ExtractNamespaces()
        {
            var namespaces = new List<Namespace>();
            var service = (DTE)Package.GetGlobalService(typeof(SDTE));
            var projects = service.Solution.Projects;
            foreach (Project project in projects)
            {
                var projectItems = GetProjectItemsRecursively(project.ProjectItems);
                foreach (ProjectItem item in projectItems.Where(i => i.FileCodeModel != null))
                {
                    foreach (CodeElement elem in item.FileCodeModel.CodeElements)
                    {
                        namespaces.AddRange(GetNamespacesRecursive(elem).Select(n=>new Namespace(n)));
                    }
                }
            }
            return namespaces.Distinct().OrderBy(n=>n.ToString()).ToList();
        }
        private static List<string> GetNamespacesRecursive(CodeElement elem)
        {
            var namespaces = new List<string>();
            if (IsNamespaceable(elem.Kind) && IsEmptyNamespace(elem))
            {
                namespaces.Add(string.Empty);
            }
            if (elem.Kind == vsCMElement.vsCMElementNamespace && !namespaces.Contains(elem.FullName))
            {
                namespaces.Add(elem.FullName);
                if (elem.Children != null)
                {
                    foreach (CodeElement codeElement in elem.Children)
                    {
                        var ns = GetNamespacesRecursive(codeElement);
                        if (ns.Count > 0)
                            namespaces.AddRange(ns);
                    }
                }
            }
            return namespaces;
        }
        private static bool IsEmptyNamespace(CodeElement elem)
        {
            return elem.FullName.IndexOf('.') < 0;
        }
        private static bool IsNamespaceable(vsCMElement kind)
        {
            return (kind == vsCMElement.vsCMElementClass
                    || kind == vsCMElement.vsCMElementEnum
                    || kind == vsCMElement.vsCMElementInterface
                    || kind == vsCMElement.vsCMElementStruct);
        }
        private static List<ProjectItem> GetProjectItemsRecursively(ProjectItems items)
        {
            var ret = new List<EnvDTE.ProjectItem>();
            if (items == null) return ret;
            foreach (ProjectItem item in items)
            {
                ret.Add(item);
                ret.AddRange(GetProjectItemsRecursively(item.ProjectItems));
            }
            return ret;
        }
    }
