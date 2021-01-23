    public static void ShowModalViewPropertyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var window = d as Window;
        ITopLevelViewModel newValue = e.NewValue as ITopLevelViewModel;
        if ((null != window) && (null != newValue))
        {
            // Search the local and Application resources for a mapping
            // between the ViewModel type of the new property and a
            // View type to use to display it.
            Type typeOfViewModel = newValue.GetType();
            Type typeOfView = (Type)window.TryFindResource(typeOfViewModel);
            if (null == typeOfView)
            {
                typeOfView = (Type)Application.Current.TryFindResource(typeOfViewModel);
            }
            // If a concrete type of the correct class is available...
            if ((null != typeOfView)&&
                (!typeOfView.IsAbstract)&&
                (typeOfView.IsSubclassOf(typeof(BaseWpfWindow))))
            {
                // Create a new window and show it as a (modal) dialog.
                BaseWpfWindow dialogWindow = (BaseWpfWindow)
                    Activator.CreateInstance(typeOfView);
                if (null != dialogWindow)
                {
                    dialogWindow.Owner = window;
                    dialogWindow.DataContext = newValue;
                    // ModalResult is a Property of ITopLevelViewModel, used to return
                    // the Window.DialogResult back to the ViewModel object.
                    newValue.ModalResult = dialogWindow.ShowDialog();
                }
            }
        }
    }
