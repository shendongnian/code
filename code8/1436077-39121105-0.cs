    public static void ShowNextImage(Image image, ImageSource source, TimeSpan fadeTime)
    {
        var fadeIn = new DoubleAnimation(1d, fadeTime);
        if (image.Source == null)
        {
            image.Source = source;
            image.BeginAnimation(UIElement.OpacityProperty, fadeIn);
        }
        else
        {
            var fadeOut = new DoubleAnimation(0d, fadeTime);
            fadeOut.Completed += (s, e) =>
            {
                image.Source = source;
                image.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            };
            image.BeginAnimation(UIElement.OpacityProperty, fadeOut);
        }
    }
