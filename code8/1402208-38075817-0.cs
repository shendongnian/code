    public class MyListBoxItem : ListBoxItem
    {
    }
    public class MyListBox : ListBox
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MyListBoxItem();
        }
    }
