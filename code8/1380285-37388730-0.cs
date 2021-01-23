    private void ButtonAddNewTask_Click(object sender, RoutedEventArgs e)
    {
    Button btn = (Button)sender;
    ProjectView curProject = (Project) btn.DataContext;
    if(null != curProject)
        {
        curProject.Project.Tasks.Add(new Task()
            {
            Name = curProject.NewTaskName
            });
        }
    }
