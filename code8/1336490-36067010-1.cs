    var result = (from user in users
                    select new User
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Tipsters = user.Tipsters.Where(x => x.Visible).Select(y => new Tipster
                        {
                            Id = y.Id,
                            Name = y.Name,
                            Visible = y.Visible,
                            Bets = y.Bets.Where(z => z.State == "Pending").Select(b => new Bet
                            {
                                Id = b.Id,
                                Name = b.Name,
                                State = b.State
                            }).AsQueryable()
                        }).AsQueryable()
                    }).AsQueryable();
