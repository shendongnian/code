    internal class MainWindowViewModel : INotifyPropertyChanged
    {
    	private ICommand addCommand;
    	private ObservableCollection<ContentItem> contentItems;
    	private ICommand deleteCommand;
    	private ContentItem selectedContentItem;
    
    	public MainWindowViewModel()
    	{
    		ContentItems.Add(new ContentItem("One", "One's content"));
    		ContentItems.Add(new ContentItem("Two", "Two's content"));
    		ContentItems.Add(new ContentItem("Three", "Three's content"));
    	}
    
    	public ObservableCollection<ContentItem> ContentItems
    	{
    		get { return contentItems ?? (contentItems = new ObservableCollection<ContentItem>()); }
    	}
    
    	public ICommand AddCommand
    	{
    		get { return addCommand ?? (addCommand = new RelayCommand(AddContentItem)); }
    	}
    
    	public ICommand DeleteCommand
    	{
    		get { return deleteCommand ?? (deleteCommand = new RelayCommand(DeleteContentItem, CanDeleteContentItem)); }
    	}
    
    	public ContentItem SelectedContentItem
    	{
    		get { return selectedContentItem; }
    		set
    		{
    			selectedContentItem = value;
    			OnPropertyChanged();
    		}
    	}
    
    	private bool CanDeleteContentItem(object parameter)
    	{
    		return SelectedContentItem != null;
    	}
    
    	private void DeleteContentItem(object parameter)
    	{
    		ContentItems.Remove(SelectedContentItem);
    	}
    
    	private void AddContentItem(object parameter)
    	{
    		ContentItems.Add(new ContentItem("New content item", DateTime.Now.ToLongDateString()));
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
  
