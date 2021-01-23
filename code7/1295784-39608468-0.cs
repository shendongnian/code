        public static class SourceControlHelper
        {
            public static void CheckoutFile(string filePath)
            {
                TFSAction((workspace) => workspace.PendEdit(filePath), filePath);
            }
    
            public static void AddFile(this Project project, string filePath)
            {
                CheckoutFile(project.FullPath);
                var projectItem = project.GetProjectItem(filePath);
                if (projectItem != null)
                {
                    return;
                }
                var includePath = filePath.Substring(project.DirectoryPath.Length + 1);
                project.AddItem(CompileType, includePath);
                project.Save();
                TFSAction(workspace => workspace.PendAdd(filePath), filePath);
            }
    
            public static void DeleteFile(this Project project, string filePath)
            {
                CheckoutFile(project.FullPath);
                var projectItem = project.GetProjectItem(filePath);
                if (projectItem == null)
                {
                    return;
                }
                project.RemoveItem(projectItem);
                project.Save();
                TFSAction(workspace => workspace.PendDelete(filePath), filePath);
            }
    
            private static ProjectItem GetProjectItem(this Project project, string filePath)
            {
                var includePath = filePath.Substring(project.DirectoryPath.Length + 1);
                var projectItem = project.GetItems(CompileType).FirstOrDefault(item => item.EvaluatedInclude.Equals(includePath));
                return projectItem;
            }
    
            private static void TFSAction(Action<Workspace> action, string filePath)
            {
                var workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(filePath);
                if (workspaceInfo == null)
                {
                    Console.WriteLine("Failed to initialize workspace info");
                    return;
                }
                using (var server = new TfsTeamProjectCollection(workspaceInfo.ServerUri))
                {
                    var workspace = workspaceInfo.GetWorkspace(server);
                    action(workspace);
                }
            }
    
            private static string CompileType
            {
                get { return CopyTool.Extension.Equals("ts") ? "TypeScriptCompile" : "Compile"; }
            }
        }
