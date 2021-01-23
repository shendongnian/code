    private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
            {
                mouseDown  = true;
                initialPoint = e.GetPosition(sender as IInputElement);
    
                if (rbtPoint.IsChecked == true)
                {
                    if (e.OriginalSource is Ellipse)
                    {
                        captured = true;
                        shapePoint = e.GetPosition(sender as IInputElement);
    		            var frozen = (Ellipse)e.OriginalSource;
                        clickedEllipse = frozen.Clone();
                        myCanvas.Children.Remove(frozen);
                        myCanvas.Children.Add(clickedEllipse);
                        uielement = (UIElement)clickedEllipse;
                    }
                    else
