        private void textBlock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            if (tb != null)
            {
                Grid parent = tb.Parent as Grid;
                if(parent != null)
                {
                    if(parent.ActualWidth < tb.ActualWidth)
                    {
                        tb.FontSize -= 10;
                    }
                }
            }
        }
