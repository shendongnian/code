      try
                {
                    using (var context = new ApplicationDbContext())
                    {
                        //Here you execute the single query
                        var query = context.Notifications.Where(c => c.recipient.Id == idOfUser)
     .Include(n => n.recipient)
                            .Include(n => n.recipient.MyProfile)
                            .Include(n => n.recipient.MyProfile.ProfileImages)
                            .Include(n => n.Message)
                            .Include(n => n.Message.Author)
                            .Include(n => n.Message.Author.MyProfile)
                            .Include(n => n.Message.Author.MyProfile.ProfileImages)
                            .Include(n => n.Message.Recipient)
                            .Include(n => n.Message.Recipient.MyProfile)
                            .Include(n => n.Message.Recipient.MyProfile.ProfileImages)
    .Include(n => n.Viewer)
                            .Include(n => n.Viewer.MyProfile)
                            .Include(n => n.Viewer.MyProfile.ProfileImages)
    .ToList(); 
        
                        ofNewMessageNotificationType = query.OfType<NewMessageNotification>().Any() ? 
                            query.OfType<NewMessageNotification>(): null;
        
                        ofProfileViewNotificationType = query.OfType<ProfileViewNotification>().Any() ? 
                            query.OfType<ProfileViewNotification>() : null;
        
                        }
        
                }
                catch (Exception ex)
                {
                    //Log issue
                }
        
                if (ofNewMessageNotificationType != null)
                {
                    foreach (var n in ofNewMessageNotificationType)
                    {
                        resultAsApiViewModel.Add(NotificationApiViewModel.ConvertToApiViewModel(n));
                    }
                }
        
                if (ofProfileViewNotificationType != null)
                {
                    foreach (var n in ofProfileViewNotificationType)
                    {
                        resultAsApiViewModel.Add(NotificationApiViewModel.ConvertToApiViewModel(n));
                    }
                }
        
                return resultAsApiViewModel;
            }
