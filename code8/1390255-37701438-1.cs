             void Drag_ManipulationDelta(object sender,ManipulationDeltaRoutedEventArgs e)
           {
                    // Move the rectangle.
                      Image img = sender as Image;
                      CompositeTransform ct = img.RenderTransform as CompositeTransform;
                      ct.ScaleX *= e.Delta.Scale;
                       ct.ScaleY *= e.Delta.Scale;
            
                        if (ct.ScaleX < 1.0) ct.ScaleX = 1.0;
                        if (ct.ScaleY < 1.0) ct.ScaleY = 1.0;
                        if (ct.ScaleX > 4.0) ct.ScaleX = 4.0;
                        if (ct.ScaleY > 4.0) ct.ScaleY = 4.0;
            //Checking with canvas boundary so that image wont go behind canvas
           if ((ct.TranslateX + e.Delta.Translation.X) <= (mycanvas.ActualWidth - img.ActualWidth) && ct.TranslateX + e.Delta.Translation.X>=0)
              ct.TranslateX += e.Delta.Translation.X;
           if ((ct.TranslateY + e.Delta.Translation.Y) <= (mycanvas.ActualHeight - img.ActualHeight) && ct.TranslateY + e.Delta.Translation.Y >= 0)
               ct.TranslateY += e.Delta.Translation.Y;
            
          } 
            
                private void Stickers1_SelectionChanged(object sender,SelectionChangedEventArgs e)
                {
                    ...
                    //Using CompositeTransform instead of TranslateTransform
                    CompositeTransform ct = new CompositeTransform();
                    imageitem.RenderTransform = ct;
                }  
        
               
                                                    
