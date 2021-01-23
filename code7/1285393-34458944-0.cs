    var accounts = context.Accouts
                          .Select(a => new Account
                                    {
                                         Number = Guid.Empty,
                                         Prop1 = a.Prop1,
                                        // map other properties
                                    });
