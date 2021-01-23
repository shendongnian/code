    private void myCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        Point pt = e.GetPosition((Canvas)sender);
        HitTestResult result = VisualTreeHelper.HitTest(myCanvas, pt);            
        if (result != null)
        {
            DependencyObject ob = VisualTreeHelper.GetParent(result.VisualHit as Shape);
            if (ob.GetType() == typeof(ContentControl)
                myCanvas.Children.Remove(ob as ContentControl);           
        }
    } 
 
