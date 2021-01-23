    public void ConstructUserFeed()
            {
                try
                {
                    //get all user ids
                    var userIds = userBL.GetIds();
                    //get all featured stories
                    var featStories = storyBL.GetFeaturedStories();
    
    // Fetch all in one query.
    IDictionary<int,IEnumerable<int>> allFollowedCategoryIds= userCategoriesBL.GetFollowedCategoryIds(userIds);
    // Fetch all in one query
    IDictionary<int,IEnumerable<int>> allUserFollowers = userFollowersBL.GetFollowedUserIds(userIds);
    
                    if (userIds != null && userIds.Count > 0)
                    {
                        foreach (var userId in userIds)
                        {
                            //integer List to store the stories ids in correct order
                            List<int> storyIdsLst = new List<int>();
                            //integer List for excluding duplicates
                            List<int> exceptStoryIds = new List<int>();
                            //user feed List to store the stories
                            var userFeed = new List<UserFeedDTO>();
                            //string to store the id list so we can add it later in db
                            string storyIds = "";
    
                            if (featStories != null && featStories.Count > 0)
                            {
                                foreach (var featStory in featStories)
                                {
                                    //first add all the ids of featured stories except own user stories, ordered by date
                                    if (featStory.authorId != userId)
                                    {
                                        storyIdsLst.Add(featStory.id);
                                        exceptStoryIds.Add(featStory.id);
                                    }
                                }
                            }
    
                            //get user's followed categories ids
                            var followedCategoryIds = allFollowedCategoryIds[userId]
    
                            if (followedCategoryIds != null && followedCategoryIds.Count > 0)
                            {
                                foreach (var categoryId in followedCategoryIds)
                                {
                                    //get the user's 5 latest stories for every followed category
                                    //except own stories and previous stories
                                    var storiesByCateg = storyBL.GetByCategory(5, categoryId, userId, exceptStoryIds);
    
                                    if (storiesByCateg != null && storiesByCateg.Count > 0)
                                    {
                                        foreach (var storyByCateg in storiesByCateg)
                                        {
                                            userFeed.Add(storyByCateg);
                                            exceptStoryIds.Add(storyByCateg.id);
                                        }
                                    }
                                }
                            }
    
                            //get user's followed users ids
                            var followedUserIds = allUserFollowers[userId];
    
                            if (followedUserIds != null && followedUserIds.Count > 0)
                            {
                                foreach (var followedId in followedUserIds)
                                {
                                    //get the user's 5 latest stories for every followed user
                                    //except own stories and previous stories
                                    var storiesByFollowedUsers = storyBL.GetByFollowedUser(5, followedId, userId, exceptStoryIds);
    
                                    if (storiesByFollowedUsers != null && storiesByFollowedUsers.Count > 0)
                                    {
                                        foreach (var storyByFollowedUsers in storiesByFollowedUsers)
                                        {
                                            userFeed.Add(storyByFollowedUsers);
                                        }
                                    }
                                }
                            }
    
                            // order the stories by date
                            userFeed = userFeed.OrderByDescending(story => story.dateAdded).ToList(); 
    
                            if (userFeed != null && userFeed.Count > 0)
                            {
                                foreach (var story in userFeed)
                                {
                                    //add the story ids after the featured story ids
                                    storyIdsLst.Add(story.id);
                                }
                            }
    
                            //comma separated list of story ids as string so we can store it in db 
                            storyIds = string.Join(",", storyIdsLst.Select(n => n.ToString()).ToArray());
    
                            //create the UserFeed model
                            UserFeed userFeedModel = new UserFeed();
                            userFeedModel.userId = userId;
                            userFeedModel.storyListId = storyIds;
                            userFeedModel.lastUpdateTime = DateTime.Now;
    
                            userFeedBL.AddOrUpdateUserFeed(userFeedModel);
                        }
                        uof.Save();
                    }
                }
    
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred in processing job. Error : {0}", ex.Message);
                }
            }
