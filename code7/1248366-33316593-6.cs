    var groups = db.some_table.Where(x => x.isOpen == true && listOfUserIds.Contains(x.Id))
                            .Select(t => new Models.SomeModel() {
                                Id = t.Id,
                                Name = t.name,
                                Users = t.Users.Where(x => x.Age > 25).Select(user => new Models.UsersModel()
                                {
                                    Name = user.Name,
                                    UserId = user.UserId
                                })
                            });
