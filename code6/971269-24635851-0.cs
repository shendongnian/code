    //create the data template
    DataTemplate objDataTemplate = new DataTemplate();
    objDataTemplate.DataType = typeof(CreditCardPayment);
    //set up the stack panel
    FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(StackPanel));
    spFactory.Name = "myFactory";
    spFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal); // Use Oritentation.Vertical if appropriate.
    //Your code for creating the buttons goes here.
    //set the visual tree of the data template
    objDataTemplate.VisualTree = spFactory;
