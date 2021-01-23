    private async void InProgressListView_Drop(object sender, DragEventArgs e)
    {
        ObservableCollection<Tasks> sourceListView = upcomingListView?.ItemsSource as ObservableCollection<Tasks>;
        await vm.IPLV_Drop(sourceListView, sender, e);
    }
____
    public async Task IPLV_Drop(ObservableCollection<Tasks> source, object sender, DragEventArgs e)
    {
        var id = await e.DataView.GetTextAsync();
        var tasksToMove = id.Split(',');
        var inProgressListView = sender as ListView;
        var IPLVItemsSource = inProgressListView?.ItemsSource as ObservableCollection<Tasks>;
        ObservableCollection<Tasks> test = source; // TODO: Change var name
        
        if (IPLVItemsSource != null)
        {
            foreach (var taskId in tasksToMove)
            {
                var taskToMove = test.First(I => i.Id.ToString() == taskId);
      
                source.Remove(taskToMove);
                taskToMove.Status = "In Progress";
                IPLVItemsSource.Add(taskToMove);
                await UpdateTask(taskToMove);
                await RefreshTasks();
            }
        }
    }
