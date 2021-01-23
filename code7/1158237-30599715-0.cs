    var listOfThings = (from ta in this.Context.TableA
                              join tb in this.Context.TableB on ta.Id equals tb.Id
                              join tc in blah
                              join td in blah
                              join te in blah
                              join tf in blah
                              join tg in blah
                              where (someConditionIsTrueOk)
                              select new YourNewClass { Tg = tg, Te = te, and so on }).ToList();   
