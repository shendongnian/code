    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var passedData = e.Parameter as PassedData; //cast the object back to PassedData type.
        someTextBlockOnBasket.Text = passedData.Name;
    }
