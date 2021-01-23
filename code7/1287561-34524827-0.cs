    public List<UserInfo> GetAllUserInfoDetailes()
            {
                List<UserInfo> user = new List<UserInfo>();
                using (Model1 pubs = new Model1())
                {
                    var userId = (from p in pubs.TB_UserInfo select p);
                    foreach (TB_UserInfo singleUser in userId)
                    {
                        UserInfo a = new UserInfo();
                        a.EUserId = singleUser.User_Id;               
                        a.EUser_Name = singleUser.User_Name;
                        a.EAlias = singleUser.Alias;
                        a.EPassword = singleUser.Password;
                        a.EState = singleUser.State;
                        a.ECurrentPrevious = singleUser.CurrentPrevious;
                        a.EEmail = singleUser.Email;
                        a.EReportDutyTime = singleUser.ReportdutyTime;
                        a.ETeam_Id = singleUser.Team_Id;
                        a.ELogin_Time = DateTime.Now;
                        user.Add(a);
                    }
                }
                return user;
            }
