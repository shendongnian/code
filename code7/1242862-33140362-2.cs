    private void myCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        DependencyObject ob = FindAncestor<ContentControl>((DependencyObject)e.Source);
        if (ob.GetType() == typeof(ContentControl))
                myCanvas.Children.Remove(ob as ContentControl);           
        
    }
    public T FindAncestor<T>(DependencyObject dependencyObject)
            where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);
            if (parent == null) return null;
            var parentT = parent as T;
            return parentT ?? FindAncestor<T>(parent);
        }
 
 
