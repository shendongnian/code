    public class ChatDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MessageFromTemplate { get; set; }
        public DataTemplate MessageToTemplate { get; set; }
    
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            MessageEntity msg = item as MessageEntity;
            if (msg != null)
            {
                if (msg.MessageType == MessageEntity.MsgType.From)
                    return MessageFromTemplate;
                else
                    return MessageToTemplate;
            }
            return null;
        }
    }
