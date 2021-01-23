    List<DependencyObject> hitResultsList = new List<DependencyObject>();
    private void WrapPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        Window wp = sender as Window;
        // Retrieve the coordinate of the mouse position.
        Point pt = e.GetPosition((UIElement)sender);
        bool elementFound = false;
        foreach (Point point in GetPointsInCircle(pt, 8, pt, new Point(2, 2)))
        {
             // Clear the contents of the list used for hit test results.
             Debug.Print(point.ToString());
             hitResultsList.Clear();
             // Set up a callback to receive the hit test result enumeration.
             VisualTreeHelper.HitTest(wp, null,
                    new HitTestResultCallback(MyHitTestResult),
                    new PointHitTestParameters(point));
             // Perform actions on the hit test results list.
             foreach (DependencyObject d in hitResultsList)
             {
                 if (d is Path)
                 {
                     Path p = d as Path;
                     if (p.Name == "link1")
                     {
                         elementFound = true; //Here we found the Path with name link1, we could then select it
                         break;
                      }
                  }
             }
             if (elementFound) break;
       }
           
    }
