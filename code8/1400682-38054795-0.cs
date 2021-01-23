    private void btn2_Click(object sender, RoutedEventArgs e)
    {       
        GeneralTransform transform = Rect2.TransformToVisual(MainCanvas);
        Rect rect = transform.TransformBounds(new Rect(0, 0, Rect2.Width, Rect2.Height));
        ChildCanvas2.Children.Remove(Rect2);
        MainCanvas.Children.Remove(ChildCanvas2);
        Canvas.SetLeft(Rect2, rect.Left);
        Canvas.SetTop(Rect2, Canvas.GetTop(Rect2) + Canvas.GetTop(ChildCanvas2));
        MainCanvas.Children.Add(Rect2);      
    }
