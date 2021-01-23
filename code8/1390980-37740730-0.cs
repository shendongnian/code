    public class TreeItem : INotifyPropertyChanged
    {
        private bool _IsExpanded;
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set { _IsExpanded = value; OnPropertyChanged("IsExpanded"); }
        }
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { _IsSelected = value; OnPropertyChanged("IsSelected"); }
        }        
        public void Focus(TreeView tView)
        {
            TreeViewItem tvItem = (TreeViewItem)tView.ItemContainerGenerator.ContainerFromItem(this);
            tvItem?.Focus();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
