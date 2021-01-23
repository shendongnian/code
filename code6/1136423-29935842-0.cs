    public async Task<IQueryable<Document>> GetDocuments(...)      
       var documents = await documentService.GetDocuments(this, userId,
                    roleShowFullNumber, param.OrderColName(), param.SearchValue, filter);
      var usersGroupsId = filter.UsersGroupsId;
            if (usersGroupsId != null)
            {
                if (!usersGroupsId.Contains("All"))
                {
                    IQueryable<Document> myDocs = null;
                    if (usersGroupsId.Contains("myOrders"))
                    {
                        myDocs = documents.Where(x => x.OwnerId == userId || x.UserId == userId);
                        usersGroupsId = usersGroupsId.Where(x => x != "myOrders").ToArray();
                    }
                    IQueryable<Document> wards = null;
                    if (usersGroupsId.Contains("wards"))
                    {
                        var relatedUserId = _db.Users.Where(x => x.Id == userId).Select(x => x.RelatedUserId).FirstOrDefault();
                        if (relatedUserId != null)
                        {
                            var myWards = _db.kh__Kontrahent.Where(x => x.kh_IdOpiekun == relatedUserId);
                            var myWardsUsers = _db.Users.Where(x => myWards.Any(w => w.kh_Id == (x.RelatedCustomerId == null ? -1 : x.RelatedCustomerId)));
                            wards = documents.Where(x => (myWardsUsers.Any(w => x.UserId == w.Id) || myWardsUsers.Any(w => x.OwnerId == w.Id)));
                            usersGroupsId = usersGroupsId.Where(x => x != "wards").ToArray();
                        }
                    }
                    IQueryable<Document> groups = null;
                    if (usersGroupsId.Length > 0)
                    {
                        var usersGroups = _db.Groups.Where(x => usersGroupsId.Contains(x.Id.ToString()));
                        var usersList = usersGroups.Select(x => x.Users);
                        var users = usersList.SelectMany(x => x);
                        var usersId = users.Select(x => x.Id);
                        groups = _db.Documents.Where(x => (usersId.Any(u => u == x.OwnerId) || usersId.Any(u => u == x.UserId)));
                    }
                    if(myDocs != null)
                        documents = documents.Union(myDocs);
                    if(wards != null)
                        documents = documents.Union(wards);
                    if(groups != null)
                        documents = documents.Union(groups);
                  
                }
            }
