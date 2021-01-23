    protected async override void OnAppearing()
    {
        base.OnAppearing();
 
        App.TodoManager.TodoViewModel.TodoItems = await App.TodoManager.GetTasksAsync();
           
        listViewTasks.ItemsSource = App.TodoManager.TodoViewModel.TodoItems;
    }
