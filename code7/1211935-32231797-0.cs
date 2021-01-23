    public Button buttonName;
    private void method ()
    {
       buttonName = this.FindName("myBtn") as Button;
       buttonName.Background = new SolidColorBrush(Color.FromRgb(255, 0, 255));
    }
