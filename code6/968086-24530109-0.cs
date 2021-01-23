    Messenger.Default.Register<ViewName>(this, ShowPropertyWindow);
    private void ShowPropertyWindow(ViewName view)
    {
      if(view == ViewName.PropertyWindow)
      {
        var propertyWindow = new PropertyWindow();
        propertyWindow.DataContext = new PropertyWindowViewModel();
        propertyWindow.Show();
      }
    }
