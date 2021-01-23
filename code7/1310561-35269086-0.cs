     private void TimersCollectionWindow_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                //Disable Double click inside the Title Bar
                var elem = VisualTreeHelper.HitTest(FloatingContainerHeader, e.GetPosition(FloatingContainerHeader));
                if (elem != null) e.Handled = true;
    
                
            }
