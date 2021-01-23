     var textblock = win.sp_s.Children.OfType<TextBlock>().FirstOrDefault();
     if (textblock.Visibility == System.Windows.Visibility.Visible)
         {
             sampleText.Visibility = System.Windows.Visibility.Visible;
         }
