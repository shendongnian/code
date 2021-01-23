        public class MultiColumnPanel : Panel
    {
        public static readonly DependencyProperty ColumnWidthProperty = DependencyProperty.Register("ColumnWidth", typeof(double), typeof(MultiColumnPanel), new PropertyMetadata(0d));
        public double ColumnWidth
        {
            get { return (double)this.GetValue(ColumnWidthProperty); }
            set { this.SetValue(ColumnWidthProperty, value); }
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            Size size = new Size();
            Size finalSize = availableSize;
            finalSize.Height = double.PositiveInfinity;
            int i = 0;
            while (i < this.Children.Count)
            {
                double tempHeight = 0d; for (int j = 0; j < (Convert.ToInt32(Window.Current.Bounds.Width / 160)); j++)
                {
                    if ((i + j) >= this.Children.Count)
                    {
                        break;
                    }
                    UIElement element = this.Children[i + j];
                    if (element != null)
                    {
                        element.Measure(availableSize);
                        tempHeight = Math.Max(tempHeight, element.DesiredSize.Height);
                    }
                }
                size.Height += tempHeight;
                i += (Convert.ToInt32(Window.Current.Bounds.Width / 160)); ;
            }
            size.Width = this.ColumnWidth * (Convert.ToInt32(Window.Current.Bounds.Width / 160)); return size;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            UIElementCollection children = this.Children;
            double heightDelta = 0d;
            int i = 0;
            while (i < this.Children.Count)
            {
                double tempHeight = 0d; for (int j = 0; j < (Convert.ToInt32(Window.Current.Bounds.Width / 160)); j++)
                {
                    if ((i + j) >= this.Children.Count)
                    {
                        break;
                    }
                    UIElement element = children[i + j];
                    if (element != null)
                    {
                        Rect finalRect = new Rect(new Point(), finalSize); finalRect.X = j * this.ColumnWidth;
                        finalRect.Y += heightDelta;
                        tempHeight = Math.Max(tempHeight, element.DesiredSize.Height);
                        finalRect.Height = element.DesiredSize.Height;
                        finalRect.Width = Math.Max(this.ColumnWidth, element.DesiredSize.Width);
                        
                        element.Arrange(finalRect);
                    }
                }
                heightDelta += tempHeight;
                i += (Convert.ToInt32(Window.Current.Bounds.Width / 160));
            }
            return finalSize;
        }
    }
