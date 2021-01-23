    private void Visibility_TitleBar(bool visible) {
        var coreTitleBar = Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar;
        coreTitleBar.ExtendViewIntoTitleBar = !visible;
        Window.Current.SetTitleBar(MyTitleBar);
    }
  
