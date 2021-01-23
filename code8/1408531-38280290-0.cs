    public class MessageDataTemplateSelecotr : DataTemplateSelector
    {
        public DataTemplate NormalTemplate { get; set; }
        public DataTemplate JoinedTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var message = item as MessageModel;
            if (message.MessageType.ToString() == "Normal")
                return NormalTemplate;
            else
                return JoinedTemplate;
        }
    }
