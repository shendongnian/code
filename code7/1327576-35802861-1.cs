    public class MyItemContainerStyleSelector : StyleSelector
    {
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var listView = ItemsControl.ItemsControlFromItemContainer(container) as ListView;
            var index = listView.ItemContainerGenerator.IndexFromContainer(container);
            var color = (index % 2 == 0) ? Colors.Red : Colors.Blue;
            var setter = new Setter
            {
                Property = ListViewItem.BackgroundProperty,
                Value = new SolidColorBrush(color)
            };
            var style = new Style { TargetType = typeof(ListViewItem) };
            style.Setters.Add(setter);
            return style;
        }
    }
