    private void myCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        DependencyObject ob = ((DependencyObject)e.Source).TryFindParent<ContentControl>();
        if (ob.GetType() == typeof(ContentControl))
                myCanvas.Children.Remove(ob as ContentControl);           
        
    } 
 
