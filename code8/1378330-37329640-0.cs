    public class TabItemDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            var viewModel = item as TabItem;
            // null check and what to do about it skipped
            return base.SelectTemplate(viewModel.Content, container);
        }
    }
