    public SlideInFromDirection SlideInFrom
    {
        get { return (SlideInFromDirection)GetValue(SlideInFromProperty); }
        set { SetValue(SlideInFromProperty, value); }
    }
    public static readonly DependencyProperty SlideInFromProperty =
        DependencyProperty.Register("SlideInFrom", typeof(SlideInFromDirection), typeof(SlideGrid), new PropertyMetadata(SlideInFromDirection.Left, slideInFromPropertyChangedCallback));
    
    private static void slideInFromPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        SlideGrid sg = d as SlideGrid;
        if (sg != null && e.NewValue is SlideInFromDirection)
        {
            if (sg.VSExpandedX == null || sg.VSExpandedY == null)
                return;
            SlideInFromDirection sd = (SlideInFromDirection)e.NewValue;
            switch (sd)
            {
                case SlideInFromDirection.Left:
                    sg.VSExpandedX.From = -300.0;
                    sg.VSExpandedY.From = 0.0;
                    break;
                case SlideInFromDirection.Right:
                    sg.VSExpandedX.From = 300.0;
                    sg.VSExpandedY.From = 0.0;
                    break;
                case SlideInFromDirection.Top:
                    sg.VSExpandedX.From = 0.0;
                    sg.VSExpandedY.From = -300.0;
                    break;
                case SlideInFromDirection.Bottom:
                    sg.VSExpandedX.From = 0.0;
                    sg.VSExpandedY.From = 300.0;
                    break;
            }
        }
    }
