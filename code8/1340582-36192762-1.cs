    var query= context.PersonCreditCard.GroupBy(c=>c.CreditCard.CardType)
                                       .Select(g=>new {
                                                        cname = g.Key,
                                                        cptPerson = g.Count()
                                                      }
                                              );
