    class MainWindowViewModel {
      TreeViewItemViewModel selectedItem;
      public MainWindowViewModel() {
        SetSelectedItemCommand = new RelayCommand<TreeViewItemViewModel>(SetSelectedItem);
      }
      public TreeViewItemViewModel SelectedItem {
        get { return selectedItem; }
        set {
          selectedItem = value;
          OnPropertyChanged();
        }
      }
      void SetSelectedItem(TreeViewItemViewModel viewModel) {
        SelectedItem = viewModel;
      }
    }
