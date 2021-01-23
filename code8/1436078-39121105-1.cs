    public static void ShowNextImage(Image image, ImageSource source, TimeSpan fadeTime)
    {
        if (image.Source == null) // no fade out
        {
            image.Source = source;
            image.BeginAnimation(UIElement.OpacityProperty,
                new DoubleAnimation(0d, 1d, fadeTime));
        }
        else
        {
            var fadeOut = new DoubleAnimation(0d, fadeTime);
            fadeOut.Completed += (s, e) =>
            {
                image.Source = source;
                image.BeginAnimation(UIElement.OpacityProperty,
                    new DoubleAnimation(1d, fadeTime));
            };
            image.BeginAnimation(UIElement.OpacityProperty, fadeOut);
        }
    }
