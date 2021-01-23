    RemoteDirectoryInfo RemoteDirectory;
         if (RemoteDirectoryPath != "Home")
              RemoteDirectory  = MySession.ListDirectory(RemoteDirectoryPath);
         else
              RemoteDirectory = MySession.ListDirectory("/");
         if (tvRemoteDirectory.SelectedNode.Nodes.Count > 0) tvRemoteDirectory.SelectedNode.Nodes.Clear();
                 
         foreach (RemoteFileInfo fileinfo in RemoteDirectory.Files)
         {                    
            if (fileinfo.IsDirectory)
            {
               if (fileinfo.Name != "." &&
                   fileinfo.Name != "..")
                   {                                                    
                       TreeNode ChildNode = new TreeNode();
                       ChildNode.Text = fileinfo.Name;
                       ChildNode.ImageIndex = 0;                                                     
                       tvRemoteDirectory.SelectedNode.Nodes.Add(ChildNode);
                       tvRemoteDirectory.ExpandAll();
                   }          
             }                    
         }
