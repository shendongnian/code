    int[] listOfUserIds = new int[]{1,2,5};
    HashSet<int> hash = new HashSet<int>(listOfUserIds);
        
    var groups = db.some_table.Where(x => x.isOpen == true && hash.Contains(x.Id))
                                .Select(t => new Models.SomeModel() {
                                    Id = t.Id,
                                    Name = t.name,
                                    Users = t.Users.Where(x => x.Age > 25).Select(user => new Models.UsersModel()
                                    {
                                        Name = user.Name,
                                        UserId = user.UserId
                                    })
                                });
