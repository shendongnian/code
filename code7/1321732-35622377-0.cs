     var groupUsers = new List<User>();
    
                foreach (var groupName in roleGroups)
                {
                    var groups = client.Groups.Where(g => g.DisplayName == groupName).Expand(g => g.Members)
                        .ExecuteAsync()
                        .Result.CurrentPage.ToList();
    
                    var users = groups.SelectMany(g => g.Members.CurrentPage.Select(m => m as User)).Where(u => u != null);
    
                    if (users.Any())
                    {
                        groupUsers.AddRange(users);
                    }
                }
