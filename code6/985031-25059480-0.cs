    public MainWindow()
    {
        InitializeComponent();
        //gr is the name of the Grid
        basepr1 = gr.RowDefinitions[0].Height;
        basepr2 = gr.RowDefinitions[2].Height;
    }
    static GridLength zero = new GridLength(0);
    GridLength basepr1;
    GridLength basepr2;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (this.LowerPanel.Visibility == Visibility.Visible)
        {
            this.LowerPanel.Visibility = Visibility.Collapsed;
            basepr2 = gr.RowDefinitions[2].Height; // remember previos height
            gr.RowDefinitions[2].Height = zero;
        }
        else
        {
            this.LowerPanel.Visibility = Visibility.Visible;
            gr.RowDefinitions[2].Height = basepr2;
        }
    }
