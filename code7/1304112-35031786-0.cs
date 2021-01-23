    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(String), typeof(MyRichTextBlock), new PropertyMetadata("", OnTextChange));
    private static void OnTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var rtb = (MyRichTextBlock)d;
        rtb.SetRichTextBlock(e.NewValue.ToString());
    }
