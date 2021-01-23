    protected override DataTemplate SelectTemplateCore(object item)
    {
        var message = item as MessageViewModel;
        if (message == null)
        {
            return SentTemplate;
        }
        return message.Sent ? SentTemplate : ReceivedTemplate;
    }
    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        return SelectTemplateCore(item);
    }
