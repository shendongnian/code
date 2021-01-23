     public partial class MainWindow : Window
     {
    // This must be private
    private int _myContolId;
    public MainWindow()
    {
        InitializeComponent();
    }
    public void Start()
    {
        // ID must be set here.
        _myControlId = 1;
        MyControl myControl = new MyControl();
        myControl.Start(_myControlId);
        
        GridContainer.Children.Add(myControl);
    }
