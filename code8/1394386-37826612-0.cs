    private void containerCanvas_MouseMove(object sender, MouseEventArgs e)
    {
        Point p = Mouse.GetPosition(Application.Current.MainWindow);
        floatingLabel.Margin = new Thickness(p.X, p.Y, 0, 0); 
    }
