    public MainWindow()
    {
        InitializeComponent();
        fbtnTest.MainText = "a";
        fbtnTest.Variations = new List<string>() { "b", "c", "d", "e", "f", "g" };
        fbtnTest.ValueClicked += fbtnTest_ValueClicked;
    }
    private void fbtnTest_ValueClicked(string value)
    {
        MessageBox.Show("Clicked: " + value);
    }
}
