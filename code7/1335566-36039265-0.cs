    // Get a list of todays activities already in the user
            List<Activity> todaysActivities = user.Activities
                .Where(x => x.ActivityDateTime >= activityDate.Date && x.ActivityDateTime < activityDate.AddDays(1).Date)
                .ToList();
                        // remove the activities from the user
            foreach (var a in todaysActivities)
            {  
                    db.Entry(a).State = EntityState.Deleted;
            }
