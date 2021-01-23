    private void myButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas canvas = (Canvas)sender;
            int col = Grid.GetColumn((UIElement)canvas.TemplatedParent);
            int row = Grid.GetRow((UIElement)canvas.TemplatedParent);
        }
