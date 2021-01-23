    public override Task OnDisconnected(bool stopCalled)
            {
                    Task mytask = Task.Run(() =>
                    {
                        UserDisconnected(Context.User.Identity.Name, Context.ConnectionId);
                    });
                    
                
    
                return base.OnDisconnected(stopCalled);
            }
    private async void UserDisconnected(string un, string cId)
            {
                await Task.Delay(10000);
                string userName = un;
                string connectionId = cId;
                
                User user;
                enqueuedDictionary.TryGetValue(userName, out user);
    
                if (user != null)
                {
                    lock (user.ConnectionIds)
                    {
    
                        user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));
    
                        if (!user.ConnectionIds.Any())
                        {
    
                            User removedUser;
                            enqueuedDictionary.TryRemove(userName, out removedUser);
                            ChatSession removedChatSession;
                            groupChatSessions.TryRemove(userName, out removedChatSession);
                            UpdateQ(removedUser.QPos);
                        }
                    }
                }
            }
