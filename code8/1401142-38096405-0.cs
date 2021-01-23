    public async Task IPLV_Drop(object sender, DragEventArgs e)
    {
        var id = await e.DataView.GetTextAsync();
        var tasksToMove = id.Split(',');
        foreach(var taskToMove in tasksToMove)
        {
            __inProgressList.Add(taskToMove);
            _upcomingList.Remove(taskToMove);
        }
    
        
        //var inProgressListView = sender as ListView;
        //var IPLVItemsSource = inProgressListView?.ItemsSource as ObservableCollection<DataModel>;
    
        tasks = await taskTable.ToCollectionAsync();
    
        foreach (var taskId in taskToMove)
        {
            var taskToMove = tasks.First(t => t.Id.ToString() == taskId);
    
            //_upcomingList.Remove(taskToMove) // DOES NOT REMOVE ITEM
    
            taskToMove.Status = "In Progress";
    
            //IPLVItemsSource.Add(taskToMove); // NOW WORKS
    
            await UpdateTask(taskToMove); //this used for update database?
        }
    }
