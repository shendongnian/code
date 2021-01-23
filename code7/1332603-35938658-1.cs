                List<Client> clients = ... //your list here;
    
                clients.GroupBy(x => x.Name)
                    .Select(
                        x =>
                            new
                            {
                                ClientName = x.Key,
                                DnoList =
                                    x.ToList()
                                        .Select(
                                            dn =>
                                                new
                                                {
                                                    DnoId = dn.DnoId,
                                                    Dno = dn.Dno,
                                                    DfullList =
                                                        x.ToList()
                                                            .Select(df => new {DfullId = df.DfullId, Dfull = df.Dfull})
                                                })
                            });
