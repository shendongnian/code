    var TextBlock = win.sp_s.Children.OfType<TextBlock>().FirstOrDefault();
            if (TextBlock.Visibility == System.Windows.Visibility.Visible)
            {
                sampleText.Visibility = System.Windows.Visibility.Visible;
            }
