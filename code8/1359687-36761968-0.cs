    EnvDTE.ProjectItem projectItem = GetSelectedSolutionExplorerItem().Object as EnvDTE.ProjectItem;
        private EnvDTE.UIHierarchyItem GetSelectedSolutionExplorerItem()
        {
            EnvDTE.UIHierarchy solutionExplorer = dte.ToolWindows.SolutionExplorer;
            object[] items = solutionExplorer.SelectedItems as object[];
            if (items.Length != 1)
                return null;
            return items[0] as EnvDTE.UIHierarchyItem;
        }
