    public override object ProvideValue(IServiceProvider serviceProvider) {
        SolidColorBrush solidColorBrush = new SolidColorBrush(Color.FromArgb(A, R, G, B));
        solidColorBrush.Freeze();
        return solidColorBrush;
    }
