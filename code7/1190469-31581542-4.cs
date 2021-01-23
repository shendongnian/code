    public class DotcomTabItemStyleEnabledSelector : StyleSelector
    {
        private Style style = null;
        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            var tabItem = container as TabItem;
            if (tabItem != null && tabItem.IsEnabled)
            {
                if (style == null)
                    style = textBox.TryFindResource("DotcomTabItemStyle") as Style;
                return style;
            }
            return null;
        }
    }
