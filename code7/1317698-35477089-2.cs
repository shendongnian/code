    StackLayout objStackLayout = new StackLayout();
    Entry objEntry = new Entry()
    {
        FontSize = 20,
        Placeholder = "3",
        Keyboard = Keyboard.Numeric
    };
    //
    objEntry.SetBinding(Entry.TextProperty, "BaseValue", BindingMode.TwoWay);
    objStackLayout.Children.Add(objEntry);
            
    PowersViewModel objViewModel = new PowersViewModel();
    this.BindingContext = objViewModel;
    Button objButton  = new Button();
    objButton.Text = "Check value";
    objButton.Clicked+=((o2,e2)=>
    {
        DisplayAlert("",string.Format("BaseValue={0}", objViewModel.BaseValue), "OK");
    });
    objStackLayout.Children.Add(objButton);
