    public class MyStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var itemsControl = ItemsControl.ItemsControlFromItemContainer(container);
            var index = itemsControl.ItemContainerGenerator.IndexFromContainer(container);
            if (index == 0)
                return (Style)itemsControl.FindResource("FirstItemStyle");
            if (index == 1)
                return (Style)itemsControl.FindResource("SecondItemStyle");
            return base.SelectStyle(item, container);
        }
    }
