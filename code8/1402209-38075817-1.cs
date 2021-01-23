    public class MyListBoxItem : ListBoxItem
    {
    }
    public class MyListBox : ListBox
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MyListBoxItem();
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is MyListBoxItem;
        }
    }
