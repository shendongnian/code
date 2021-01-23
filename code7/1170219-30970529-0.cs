    public RecipeButton : INotifyPropertyChanged {
       // Need to implement INotifyPropertyChanged logic on IsCheckedVisiblity for UI to be notified of visibility changes
       public Visibility IsCheckedVisibility { get; set; }
       private bool _IsChecked;
       public bool IsChecked {
          get { return _IsChecked };
          set { _IsChecked = value;
                this.IsCheckedVisibility = value == true ? Visiblity.Collapsed : Visiblity.Visible;
          }
              
    }
<PopUp Visibility = "{Binding IsCheckedVisibility}"/>
