    public class ObservableViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            var tempEventHandle = PropertyChanged;
            if (tempEventHandle != null)
                tempEventHandle(this, new PropertyChangedEventArgs(propName));
        }
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
      public CategoryView Categories { get; set; } = new CategoryView();
      public SubcategoryView Subcategories { get; set; } = new SubcategoryView();
    }
