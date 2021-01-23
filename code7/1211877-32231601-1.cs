    var councillors = from c
                      in Committees
                      where c.CommitteeId = 1
                      select new
                      {
                          CommitteeName = c.Name,
                          Chairman = c.Chairman,
                          ViceChairman = c.ViceChairman,
                          Councillors = from cc
                                        in c.CouncilorCommittees
                                        select cc.Councillor
                      }
