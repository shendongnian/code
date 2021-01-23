    public class TabItemDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            var viewModel = item as TabItem;
			if (item == null)
				return null;
            else
                item = viewModel.Content;
			FrameworkElement fe = null;
			if (container is ContentPresenter)
				fe = (container as ContentPresenter)
                        .TemplatedParent as FrameworkElement;
			else
				fe = container as FrameworkElement;
			var key = new DataTemplateKey(item.GetType());
			return fe.TryFindResource(key) as DataTemplate;
        }
    }
