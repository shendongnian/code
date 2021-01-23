      var likes = db.Likes
                    .Take(10)
                    .ToList()
                    .Select(like => new NotificationsViewModel
                     {
                        Text = resolveNotificationString(like.GetType().Name),
                        Type = like.GetType().Name,
                        RelatedItem = like.Id
                     });
