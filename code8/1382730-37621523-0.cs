    private void List_MouseMove (object Sender, MouseEventArgs E)
    {
      if (allowDrag_)
      {
         Vector Difference = startPoint_ - E.GetPosition (null);
         if (Mouse.LeftButton == MouseButtonState.Pressed &&
         (Math.Abs (Difference.X) > SystemParameters.MinimumHorizontalDragDistance ||
         Math.Abs (Difference.Y) > SystemParameters.MinimumVerticalDragDistance))
         {
           PerformDragAndDrop ((DependencyObject)E.OriginalSource, (ListView)Sender);
         }
      }
    }
