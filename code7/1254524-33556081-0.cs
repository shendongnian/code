        public void OnItemSaved(object sender, EventArgs args)
        {
            var item = Event.ExtractParameter(args, 0) as Item;
            ReReferenceFieldAndRemoveNotifications(item, args);
            
            ...
        }
        private void ReReferenceFieldAndRemoveNotifications(Item srcItem, EventArgs args)
        {
            if (srcItem != null && !srcItem.Paths.Path.ToLower().Contains(string.Format("{0}/{1}", "content", "canada")))
            {
                var destItem = Database.GetDatabase("master").GetItem(srcItem.Paths.Path.Replace("United States", "Canada"));
                // Update the clone
                Rereferencer.RereferenceFields(srcItem, destItem);
                // Now reject the notifications on the clone (accepting would push the US values which we don't want)
                using (new SecurityDisabler())
                {
                    if (srcItem.HasClones)
                    {
                        var jobOptions = new JobOptions("RejectNotifications", string.Empty, Context.GetSiteName(), this, "RejectNotifications", new object[] { srcItem });
                        var job = new Job(jobOptions);
                        jobOptions.InitialDelay = new TimeSpan(0, 0, 0, 1, 0);
                        JobManager.Start(job);
                    }
                }
            }
        }
        public void RejectNotifications(Item args)
        {
            // Remove and reject any notifications on the clone.
            using (new SecurityDisabler())
            {
                var item = args;
                var clones = item.GetClones(true);
                foreach (var clone in clones)
                {
                    var notifications = clone.Database.NotificationProvider.GetNotifications(clone);
                    foreach (var notification in notifications)
                    {
                        clone.Database.NotificationProvider.RemoveNotification(notification.ID);
                        notification.Reject(clone);
                    }
                    clone.Editing.BeginEdit();
                    try
                    {
                        clone.Fields["__Workflow"].Value = args.Fields["__Workflow"].Value;
                        clone.Fields["__Workflow state"].Value = args.Fields["__Workflow state"].Value;
                    }
                    finally
                    {
                        clone.Editing.EndEdit();
                    }
                }
            }
        }
