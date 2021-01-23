    public class StripedListView : ListView
        {          
            protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
            {
                base.PrepareContainerForItemOverride(element, item);
                var listViewItem = element as ListViewItem;
                if (listViewItem != null)
                {
                    var index = IndexFromContainer(element);
    
                    if (Words.arrayW[index].Length > 0)
                    {
                        listViewItem.Foreground = new SolidColorBrush(Colors.Black);
    
                    }
                    else
                    {
                        listViewItem.Foreground = new SolidColorBrush(Colors.Gray); 
                        listViewItem.IsEnabled = false;
                    }
                }
            }
        }
