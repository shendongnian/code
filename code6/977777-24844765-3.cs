    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (Grid.GetZIndex(Rect1) == 1)
        {
            Grid.SetZIndex(Rect1, 2);
        }
        else
        {
            Grid.SetZIndex(Rect1, 1);
        }
  
        if (Grid.GetZIndex(Rect2) == 2)
        {
            Grid.SetZIndex(Rect2, 1);
        }
        else
        {
            Grid.SetZIndex(Rect2, 2);
        }
    }
