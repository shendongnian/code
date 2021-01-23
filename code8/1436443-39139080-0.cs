    myForm.DataBindings.Add(new Binding("Items", ItemsController.Singleton, "Items")
    {
        DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
        ControlUpdateMode = ControlUpdateMode.Never
    });
