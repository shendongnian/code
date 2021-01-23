    public async Task<ObservableCollection<ToDoItem>> GetTasksAsync()
    {
        try
        {
            return new ObservableCollection<ToDoItem>(await _todoTable.ReadAsync());
        }
        catch (MobileServiceInvalidOperationException msioe)
        {
            Debug.WriteLine(@"INVALID {0}", msioe.Message);
        }
        catch (Exception e)
        {
            Debug.WriteLine(@"ERROR {0}", e.Message);
        }
        return null;
    }
