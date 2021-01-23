    var firstQuery = from ta in repo.TableA
                        from tda in ta.TableDetailsA.DefaultIfEmpty()
                        from tdb in ta.TableDetailsB.DefaultIfEmpty()
                        where ta.ID == 1
                        select new
                                {
                                    TableAID = ta.ID
                                    , TableBID = (int?)tda.TableB.ID ?? (int?)tdb.TableB.ID
                                };
    
    var secondQuery = from fq in firstQuery
                        join ta in repo.TableA
                            on fq.TableAID equals ta.ID
                        join tb in repo.TableB
                            on fq.TableBID equals tb.ID
                        join tc in repo.TableC
                            on tb.TableCID equals tc.ID
                        select new
                                {
                                    TableAData = ta.Data
                                    , TableBData = tb.Data
                                    , TableCData = tc.Data
                                };
