    public class MyItemContainerStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var element = container as FrameworkElement; // this will be a ContentPresenter
            if (element == null) return null;
            var viewModel = element.DataContext;
            if (viewModel is Object1ViewModel)
            {
                return element.FindResource("Object1Style") as Style;
            }
            if (viewModel is Object2ViewModel)
            {
                return element.FindResource("Object2Style") as Style;
            }
            return null;
        }
    }
