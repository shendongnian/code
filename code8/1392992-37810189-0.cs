     //  imageitem.RightTapped += Imageitem_RightTapped;
                imageitem.Holding += Imageitem_Holding;
                imageitem.IsRightTapEnabled = true;
                imageitem.IsHoldingEnabled = true;
     private void Imageitem_RightTapped(object sender, RightTappedRoutedEventArgs e)
            {
                mycanvas.Children.Remove(sender as Image);
            }
    
            private void Imageitem_Holding(object sender, HoldingRoutedEventArgs e)
            {
                mycanvas.Children.Remove(sender as Image);
            }
