    public static readonly DependencyProperty PresentationSlideProperty =
        DependencyProperty.Register(
            nameof(PresentationSlide),
            typeof(ISlide),
            typeof(PresentationViewer),
            new PropertyMetadata(null,
                (o, e) => ((PresentationViewer)o).ShowSlideContent()));
