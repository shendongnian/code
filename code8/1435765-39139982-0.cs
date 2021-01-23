    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        //if the mainpage resource exists then load the container
        if (Application.Current.Resources.ContainsKey("mainpage"))
        {
            var resource = Application.Current.Resources["mainpage"];
            myCanvas.InkPresenter.StrokeContainer = (InkStrokeContainer)resource;
        }
    }
    //I save the StrokeContainer in a button click event
    private void myBtn_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Resources.Add(new KeyValuePair<object, object>("mainpage", myCanvas.InkPresenter.StrokeContainer));
    }
