          private static ProjectItem GetProjectItem(this Project project, string filePath)
        {
            var includePath = filePath.Substring(project.DirectoryPath.Length + 1);
            var projectItem = project.GetItems(CompileType).FirstOrDefault(item => item.EvaluatedInclude.Equals(includePath));
            return projectItem;
        }
