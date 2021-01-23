    private void helmet_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        //the code omitted for the brevity
        if (e.LeftButton == MouseButtonState.Pressed &&
      (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
       Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
        {    
            //the code omitted for the brevity
            DragDrop.DoDragDrop(listBox, dragData, DragDropEffects.Copy);
        }
    }
