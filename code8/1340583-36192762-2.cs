    var query= context.PersonCreditCard.Where(pc=>pc.Person.Name=="John")
                                       .GroupBy(c=>c.CreditCard.CardType)
                                       .Select(g=>new {
                                                        cname = g.Key,
                                                        cptPerson = g.Count()
                                                      }
                                              );
