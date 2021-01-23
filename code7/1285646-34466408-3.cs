    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var myObject = new MyCommunicationObject();
        myObject.Message = "Hello from another child window";
        this.eventAggregator.GetEvent<MyEvent>().Publish(myObject);
    }
