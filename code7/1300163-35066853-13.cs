        /// <summary>
    /// helps to define simple data template in code
    /// </summary>
    public class DataTemplateFactory
    {
        public static DataTemplate GetDataTemplateWithBindingByType(Type type, Binding binding)
        {
            var key = type.Name;
            DataTemplate template;
            switch (key)
            {
                case "String":
                {
                    template = GetStringTemplate(binding);
                }
                break;
                case "Boolean":
                {
                    template = GetBooleanTemplate(binding);
                }
                break;
                case "DateTime":
                {
                    template = GetDateTimeTemplate(binding);
                }
                break;
                default:
                    return null;
            }
            return template;
        }
        private static DataTemplate GetDateTimeTemplate(Binding binding)
        {
            DataTemplate template = new DataTemplate();
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(DatePicker));
            factory.SetValue(Control.BackgroundProperty, Brushes.CadetBlue);
            factory.SetBinding(DatePicker.SelectedDateProperty, binding);
            template.VisualTree = factory;
            return template;
        }
        
        private static DataTemplate GetBooleanTemplate(Binding binding)
        {
            DataTemplate template = new DataTemplate();
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(CheckBox));
            factory.SetValue(ContentControl.ContentProperty, "");
            factory.SetValue(Control.BackgroundProperty, Brushes.Green);
            factory.SetBinding(ToggleButton.IsCheckedProperty, binding);
            template.VisualTree = factory;
            return template;
        }
        private static DataTemplate GetStringTemplate(Binding binding)
        {
            DataTemplate template = new DataTemplate();
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(TextBlock));
            factory.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Left);
            factory.SetValue(TextBlock.BackgroundProperty, Brushes.Tomato);
            factory.SetBinding(TextBlock.TextProperty, binding);
            template.VisualTree = factory;
            return template;
        }
    }
