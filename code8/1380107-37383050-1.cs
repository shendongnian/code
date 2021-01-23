    public ISlide PresentationSlide
    {
        get { return (ISlide)GetValue(PresentationSlideProperty); }
        set { SetValue(PresentationSlideProperty, value); }
    }
    public static readonly DependencyProperty PresentationSlideProperty =
        DependencyProperty.Register(
            nameof(PresentationSlide),
            typeof(ISlide),
            typeof(PresentationViewer),
            new PropertyMetadata(null, PresentationSlidePropertyChanged));
    private static void PresentationSlidePropertyChanged(
        DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        ((PresentationViewer)o).ShowSlideContent();
    }
