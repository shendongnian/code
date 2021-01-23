    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ClientTemplate { get; set; }
        public DataTemplate ServerTemplate { get; set; }
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item.GetType() == typeof(ClientMessage))
                return ClientTemplate;
            return ServerTemplate;
        }
    }
