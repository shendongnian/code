    public ObservableCollection<ToDoItem> GetFilteredList(string searchString)
    {
        return new ObservableCollection<ToDoItem>
        (TodoViewModel.TodoItems.Where(x => x.Name.Contains(searchString)));
    }
 
