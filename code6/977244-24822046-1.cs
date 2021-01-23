    double positioningX = (Application.Current.Host.Content.ActualWidth / 2) - (widthOfDialog / 2);
    double positioningY = (Application.Current.Host.Content.ActualHeight / 2) - (heightOfDialog / 2);
    if (positioningX > 0)
        popup.HorizontalOffset = positioningX;
    if (positioningY > 0)
        popup.VerticalOffset = positioningY;
