    public MainWindow()
    {
        InitializeComponent();
        var x = 13; // this defined outside now...
        Action myAction = () => Console.WriteLine(x); // you're basically using the closure here.
        myAction();
        test(myAction);
    }
