    private void Frog_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Right)
        {
            if (Grid.GetColumn(frog) <= Grid.ColumnDefinitions.Count - 1)
                Grid.SetColumn(frog, Grid.GetColumn(frog) + 1);
        }
        else if (e.Key == Key.Up)
        {
            if (Grid.GetRow(frog) > 0)
                Grid.SetRow(frog, Grid.GetRow(frog) - 1);
        }
        else if (e.Key == Key.Down)
        {
            if (Grid.GetRow(frog) <= Grid.RowDefinitions.Count - 1)
                Grid.SetRow(frog, Grid.GetRow(frog) + 1);
        }
        else if (e.Key == Key.Left)
        {
            if (Grid.GetColumn(frog) > 0)
                Grid.SetColumn(frog, Grid.GetColumn(frog) - 1);
        }
    }
    private void Frog_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        frog.Focus();
    }
