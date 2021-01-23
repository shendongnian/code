    private List<StepItem> stepItems = new List<StepItem>{
                new StepItem{
                    Index=0,
                    Label="Step1",
                    Length=20,
                    Brush = new SolidColorBrush(Color.FromArgb(255,255,0,0)),
                new StepItem{
                    Index=4,
                    Label="Step5",
                    Length=25,
                    Brush = new SolidColorBrush(Color.FromArgb(255,0,128,0)),
               },
            };
    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        progressItemsControl1.ItemsSource = stepItems;
    }
