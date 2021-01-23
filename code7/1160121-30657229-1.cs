        <MenuItem Header="Test" UsesItemContainerTemplate="True" ItemsSource="{Binding Items}">
            <MenuItem.ItemContainerTemplateSelector>
                <local:MenuItemContainerTemplateSelector>
                    <DataTemplate>
                        <local:MenuItemDerived />
                    </DataTemplate>
                </local:MenuItemContainerTemplateSelector>
            </MenuItem.ItemContainerTemplateSelector>
        </MenuItem>
    The very simple `MenuItemContainerTemplateSelector` class I used there looks like this:
        [ContentProperty("Template")]
        internal class MenuItemContainerTemplateSelector : ItemContainerTemplateSelector
        {
            public DataTemplate Template { get; set; }
            public override DataTemplate SelectTemplate(object item, ItemsControl parentItemsControl)
            {
                return Template;
            }
        }
    You can, of course, make a complex selector with several templates to choose from if you want to.
