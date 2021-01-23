      List<string> AcceptableExtensions = new List<string>();
      AcceptableExtensions.Add(".mse");
      AcceptableExtensions.Add(".ms");
      foreach (var file in directoryInfo.GetFiles())
      {
          if (IsValidFileType(file.FullName, AcceptableExtensions))
          {
              TreeNode node = new TreeNode(file.Name, 1, 1);
              node.Tag = file.FullName;
              node.ForeColor = toolColor;
              directoryNode.Nodes.Add(node);
              // add to global fileList which is used for searches
              fileList.Add(file.FullName);
          }
      }
