    var m = new Member { Name = "m1" };
    var lm = new Member { Name = "leader" };
    var g = new Guild { Name = "g1" };
    g.LeaderMemberInfo = lm;
    g.Members.Add(lm);
    g.Members.Add(m);
    c.Set<Guild>().Add(g);
    c.SaveChanges();
