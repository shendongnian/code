    private void AnimateHeight(Grid grid)
    {
        double newHeight = grid.ActualHeight == 100 ? 300 : 100; //select the height we want to animate
        Storyboard story = new Storyboard();
        DoubleAnimation animation = new DoubleAnimation();
        animation.To = newHeight;
        animation.Duration = TimeSpan.FromSeconds(0.5);
        Storyboard.SetTarget(animation, grid);
        Storyboard.SetTargetProperty(animation, new PropertyPath(Grid.HeightProperty));
        story.Children.Add(animation);
        story.Begin();
    }
    private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        Grid grid = sender as Grid; //select the grid we tapped
        AnimateHeight(grid);
    }
