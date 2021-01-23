    // Showing the viewmodel constructor only
    public ViewModel()
    {
        this.AvailableStyles = new ObservableCollection<StyleDefinition>()
        {
            new StyleDefinition() { Name="Red", ResourceUri="Design.xaml" },
            new StyleDefinition() { Name="Green", ResourceUri="Design2.xaml" }
        };
    }
    
    // Definition of a simple data model to store style name and uri
    public class StyleDefinition
        {
            public string Name { get; set; }
            public string ResourceUri { get; set; }
        }
