    public class FilterableImageWrapGrid : FilterableContentList
        public static Point GetItemDimensions(DependencyObject obj)
        {
            return (Point)obj.GetValue(ItemDimensionsProperty);
        }
        public static void SetItemDimensions(DependencyObject obj, Point value)
        {
            obj.SetValue(ItemDimensionsProperty, value);
        }
        
        public static readonly DependencyProperty ItemDimensionsProperty =
            DependencyProperty.RegisterAttached("ItemDimensions", typeof(Point), typeof(ItemsWrapGrid), new PropertyMetadata(new Point()));
        ...
    }
