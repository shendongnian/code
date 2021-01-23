    //I'm using MVVM Light here - you need to be able to find an instance
    //of your AppBaseViewModel somehow.
    private ViewModelLocator _locator;
    //View codebehind constructor, may need to change names as appropriate
    public AppBaseView()
    {
        InitializeComponent();
    
        //MVVM Light again
        _locator = new ViewModelLocator();
    
        //Create the binding
        Binding binding = new Binding();
    
        //Source = The instance of your ViewModel
        binding.Source = _locator.AppBaseViewModel ;
        binding.Path = new PropertyPath("Text");
        binding.Mode = BindingMode.TwoWay;
        binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    
        //Create a Style with no Key - this will apply to *all* TextBoxes
        //without their own explicit Style set.
        Style style = new Style(typeof(TextBox));
        style.Setters.Add(new Setter(TextBox.TextProperty, binding));
        //Add the Style to the XAML's Resources:
        Resources.Add(typeof(TextBox), style);
    }
