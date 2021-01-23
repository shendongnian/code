    private void WorkSpaceVersion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
       Point position = e.GetPosition(WorkspaceVersion);
       var i = Math.Round(position.Y/15); // line height brah
    }
