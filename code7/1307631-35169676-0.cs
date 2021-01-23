    class MyModel
    {
        public bool IsSelected { get; set; }
    }
    class MyList : Windows.UI.Xaml.Controls.ListView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var model = item as MyModel;
            var listViewItem = element as Windows.UI.Xaml.Controls.ListViewItem;
            var binding = new Windows.UI.Xaml.Data.Binding
            {
                Source = model,
                Mode = Windows.UI.Xaml.Data.BindingMode.TwoWay,
                Path = new PropertyPath(nameof(model.IsSelected)),
            };
            listViewItem.SetBinding(Windows.UI.Xaml.Controls.ListViewItem.IsSelectedProperty, binding);
            base.PrepareContainerForItemOverride(element, item);
        }
    }
