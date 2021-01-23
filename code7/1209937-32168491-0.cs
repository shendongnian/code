    private void Rectangle_Click(object sender, RoutedEventArgs e)
    {
        var rec = new Rectangle();
        rec.Height = 100;
        rec.Width = 100;
        rec.Fill = new SolidColorBrush(Colors.Violet);
        this.ManipulationMode=ManipulationModes.All;
        rec.ManipulationDelta += rec_ManipulationDelta;
        rec.RenderTransform=new TranslateTransform(); // Create new TranslateTransform and assign to the rectangle
        board.Children.Add(rec);
    }
    void rec_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        Rectangle recSender = (Rectangle) sender; // Get the Rectangle
        TranslateTransform ttSender = this.RenderTransform as TranslateTransform; // Get the Rectangle's RenderTransform (which is a TranslateTransform)
        
        rrSender.X += e.Delta.Translation.X;
        rrSender.Y += e.Delta.Translation.Y;
    } 
