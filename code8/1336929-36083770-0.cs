         public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
                    {
                        using (DataContext dc = new DataContext())
                        {
                            var item = dc.LoggedInUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
                            if (item != null)
                            {
                                dc.LoggedInUsers.Remove(item);
                                dc.SubmitChanges();
    //If there is no other connection left with this user in this room send message.
                                   if (!dc.LoggedInUsers.Any(x => x.RoomID==item.RoomID && x.userId==item.UserId)
                                       Clients.OthersInGrouproomId.ToString()).onUserDisconnected(Context.ConnectionId, item.UserMaster.User_Name);
                               }
                            return base.OnDisconnected(stopCalled);
                        }
                    }
                }
        
                private void AddLoginUser(string room_Id, string connection_Id, string user_Id)
                {
                    using (DataContext dc = new DataContext())
                    {
    //Just check connectionId uniqunes. You don't need connected field.
                        var checkUserLogedIn = (from user in dc.LoggedInUsers
                                                where user.ConnectionId == connection_Id
                                                select user).SingleOrDefault();
                        if (checkUserLogedIn == null)
                        {
                            LoggedInUser objLoggedInUser = new LoggedInUser();
                            objLoggedInUser.ConnectionId = connection_Id;
                            objLoggedInUser.UserID = Convert.ToInt32(user_Id);
                            objLoggedInUser.RoomID = Convert.ToInt32(room_Id);
                            dc.LoggedInUsers.InsertOnSubmit(objLoggedInUser);
                            dc.SubmitChanges();
                        }
                    }
                }
