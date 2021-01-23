    public class PopupViewModel
    {
        public ObservableCollection<YourItemClass> CmbContent { get; set; }
        public YourItemClass SelectedEntry { get; set; }
        
        // Implement INotifyPropertyChanged if needed also
    }
