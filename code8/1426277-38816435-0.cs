    public class ObservableViewModelBase : INotifyPropertyChanged
    {
    // INotifyPropertyChanged implementation.
    }
    public class CategoryView : ObservableViewModelBase
    {
    public ObservableCollection<object> Items { /* */ }
    public object SelectedItem { /* ... */ }
    }
    public class SubcategoryView : ObservableViewModelBase
    {
    public ObservableCollection<object> Items { /* */ }
    public object SelectedItem { /* ... */ }
    }
 
    public class EditArticleView : ObservableViewModelBase
    {
    public CategoryView Categories = new CategoryView();
    public SubcategoryView Subcategories = new SubcategoryView();
    // Additional properties and methods here
    }
