    public class UpdateSelectedItemBehavior : Behavior<TreeView>
    {
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    
    		this.AssociatedObject.GotFocus += AssociatedObject_GotFocus;
    		this.AssociatedObject.SelectedItemChanged += AssociatedObject_SelectedItemChanged;
    	}
    
    	void AssociatedObject_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    	{
    		ViewModels.MainViewModel mainViewModel = AssociatedObject.DataContext as ViewModels.MainViewModel;
    		if (mainViewModel != null)
    		{
    			mainViewModel.SelectedItem = AssociatedObject.SelectedItem;
    		}
    	}
    
    	void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
    	{
    		ViewModels.MainViewModel mainViewModel = AssociatedObject.DataContext as ViewModels.MainViewModel;
    		if (mainViewModel != null)
    		{
    			mainViewModel.SelectedItem = AssociatedObject.SelectedItem;
    		}
    	}
    }
