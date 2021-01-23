    var allPersons = this.ObjectContext.Person.Join(this.ObjectContext.FriendVisit,
                                                    x=>x.IdPerson,
                                                    y=>y.IdPerson
                                                    (x,y)=> new { x, y }
                                             ).GroupBy(z=>z)
                                              .Select(x=> new 
                                               {
                                                   Name = p.Name;
                                                   Duration = f.OrderBy(y=>y.TimeOfVisit)
                                                               .Last()
                                                               .Duration
                                               });
