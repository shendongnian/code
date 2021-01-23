    foreach (ViewModels.FloorAssignment_VM ap in projectList)
    {
        MenuItem pmi = new MenuItem();
        string projectName = ap.Project_Name;
        projectName = projectName.Replace('_', ' ');
        pmi.Header = projectName;
        pmi.Tag = ap.ProjectKey;
        pmi.Click += new RoutedEventHandler(pmi_Click);
        pmi.Style = (Style)this.FindResource("MenuItemStyleBlue");
        MenuItem del = new MenuItem();
        del.Header = "Delete";
        del.Tag = ap.ProjectKey;
        del.Click += new RoutedEventHandler(del_Click);
        pmi.Items.Add(del);
        ProjectsMenuItem.Items.Add(pmi);
    }
