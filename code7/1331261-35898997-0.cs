    void WinFoldersTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
      switch (e.Node.Text) {
        case "Home Drive":
          Process.Start(EnvPaths.HomeDrive);
          break;
        case "Program Files":
          Process.Start(EnvPaths.ProgramFiles);
          break;
        case "Common Files":
          Process.Start(EnvPaths.CommonFiles);
          break;
        // etc...
