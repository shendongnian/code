       public List<UserInboxMsg> GetUserInboxMsg(IKASLWSEntities conx, int userid)
            {
                var u = (from m in conx.tblUsers where m.Id == userid select m).FirstOrDefault();
                if (u != null && conx != null)
            {
    
                return (from ux in u.tblInboxes
                        orderby ux.CreationTS descending
                        select new UserInboxMsg
                        {
                            ...
                            ...
                            SenderAvatar = conx.tblMessages.Any(mu=>mu.Id == ux.Id) ? (conx.tblMessages.First(mu=>mu.Id == ux.Id).tblUser != null? conx.tblMessages.First(mu=>mu.Id == ux.Id).tblUser.ImageURL : null) : null,
                            Message = ux.Message
                        }).ToList<UserInboxMsg>();
            }
            else
            {
                return new List<UserInboxMsg>();
            }
        }
    
    }
