    public class ViewSection : HubSection {
        public ViewSection(View view) {
            string xaml = "<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><StackPanel /></DataTemplate>";
            ContentTemplate = XamlReader.Load(xaml) as DataTemplate;
            this.Loaded += ViewSection_Loaded;
        }
        private void ViewSection_Loaded(object sender, RoutedEventArgs e) {
            base.OnApplyTemplate();
            StackPanel stackPanel = findStackPanelInSubtree(this);
            ...
            < adding stuff to stack panel >
            ...
            this.Loaded -= ViewSection_Loaded;
        }
        private StackPanel findStackPanelInSubtree(FrameworkElement element) {
            if (element != null) {
                if (element.GetType() == typeof(StackPanel)) {
                    return element as StackPanel;
                }
                foreach (FrameworkElement child in getChildren(element)*) {
                    StackPanel result = findStackPanelInSubtree(child);
                    if (result != null) return result;
                }
            }
            return null;
        }
        private List<FrameworkElement> getChildren(FrameworkElement element)* {
            if (element != null) {
                List<FrameworkElement> result = new List<FrameworkElement>();
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++) {
                    result.Add(VisualTreeHelper.GetChild(element, i) as FrameworkElement);
                }
                return result;
            }
            return null;
        }
    }
