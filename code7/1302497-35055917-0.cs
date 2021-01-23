        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cvs.Update += Cvs_Update;
            cvs.Draw += Cvs_Draw;
        }
        int y = 0;
        int dy = 15;
        private void Cvs_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {
            args.DrawingSession.Clear(Windows.UI.Colors.Blue);
            args.DrawingSession.FillRectangle(new Rect(0, y, 100, 100), Windows.UI.Colors.Green);
        }
        private void Cvs_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
        {
            y += dy;
            if (y > 500 || y < 0)
                dy = -dy;
        }
