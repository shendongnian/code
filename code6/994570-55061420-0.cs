    private void OnNewEvent(object sender, NotificationEventArgs args) {
        foreach (var notification in args.Events.OfType<ItemEvent>())
        {
            if (notification.EventType == EventType.Moved)
                var item = Item.Bind(service, notification.ItemId);
        }
    }
