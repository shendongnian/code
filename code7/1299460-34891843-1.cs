    public class SelectedProjectComboBoxTemplateSelector : DataTemplateSelector {
        public static DataTemplate StringTemplate { get; set; }
        public static DataTemplate ProjectTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            if (item == null || Designer.IsInDesignMode) return null;
            if (item is string) return StringTemplate;
            if (item is Project) return ProjectTemplate;
            return null;
        }
    }
