     private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
     {
            Canvas c = sender as Canvas;
            foreach (Rectangle r in c.Children)
            {
               // Invoke the handler here...
            }
      }
