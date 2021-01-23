    public abstract class AcceptCloneNotificationsEventBase<T> where T : Notification
	{
		protected abstract bool ShouldAcceptNotification(Item item, Item parent);
		public void AcceptClone_SavedItem(object sender, EventArgs args)
		{
			var item = (Item)Event.ExtractParameter(args, 0);
			var parent = item.Parent;
			foreach (var clone in item.GetClones())
			{
				foreach (var notification in clone.Database.NotificationProvider.GetNotifications(clone.Uri))
				{
					if (notification is T && ShouldAcceptNotification(item, parent)) 
					{
						notification.Accept(clone);
					}
				}
			}
		}
		public void AcceptClone_CreateItem(object sender, EventArgs args)
		{
			var item = (Item)Event.ExtractParameter(args, 0);
			var parent = item.Parent;
			foreach (var clone in parent.GetClones())
			{
				foreach (var notification in clone.Database.NotificationProvider.GetNotifications(clone.Uri))
				{
					if (notification is T && ShouldAcceptNotification(item, parent)) 
					{
						notification.Accept(clone);
					}
				}
			}
		}
	}
