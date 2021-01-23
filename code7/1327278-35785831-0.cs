    string data = "";
    
    ...
    void LoadDataAsync() {        
        //Service call populates variable.
        //When service call completes Button is enabled allowing user to click
    }   
    ...
    private void OnButtonClick(object sender, System.Windows.RoutedEventArgs e) {
        System.Windows.Clipboard.SetText(data);
    }
