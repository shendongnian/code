    private void OnAssociatedObjectMouseMove (object sender, MouseEventArgs e)
    {
        if (mouseIsDown)
        {
            AssociatedObject.Background = new SolidColorBrush(Colors.Red);
            var effects = DragDrop.DoDragDrop((DependencyObject)sender,
                                AssociatedObject.Content,
                                DragDropEffects.Link);
            // this line will be executed, when drag/drop will complete:
            AssociatedObject.Background = //restore color here;
            if (effects == DragDropEffects.None)
            {
                // nothing was dragged
            }
            else
            {
                // inspect operation result here
            }
        }
    }
