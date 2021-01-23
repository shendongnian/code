    public class ZCombobox:ComboBox
        {
            protected override void PrepareContainerForItemOverride(Windows.UI.Xaml.DependencyObject element, object item)
            {
                ComboBoxItem zitem = element as ComboBoxItem;
    
                if (zitem != null)
                {
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("IsSelectable");
                    zitem.SetBinding(ComboBoxItem.IsEnabledProperty, binding);
                }
                base.PrepareContainerForItemOverride(element, item);
            }
        }
