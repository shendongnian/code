    public static readonly DependencyProperty NumOfLabelsProperty =
        DependencyProperty.Register(
            "NumOfLabels", typeof(int), typeof(MyUserControl1),
            new PropertyMetadata(0, NumOfLabelsPropertyChanged));
    public int NumOfLabels
    {
        get { return (int)GetValue(NumOfLabelsProperty); }
        set { SetValue(NumOfLabelsProperty, value); }
    }
    private static void NumOfLabelsPropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        ((MyUserControl1)obj).LabelsRender();
    }
