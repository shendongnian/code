    public class MyListView : Windows.UI.Xaml.Controls.ListView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var item = element as Windows.UI.Xaml.Controls.ListViewItem;
            base.PrepareContainerForItemOverride(element, item);
        }
    }
