    var groups = new List<List<int>>();
    foreach (var con in connectionList)
    {
        if(!groups.Any(g => g.Contains(con.X) || g.Contains(con.Y)))
        {
            groups.Add(new List<int>() { con.X, con.Y }); //con.X is not part of any group, so we can create a new one with X and Y added, since both a are in the group       
        } 
        else 
        {
            var group = groups.First(g => g.Contains(con.X) || g.Contains(con.Y));
            if(!group.Contains(con.X)) group.Add(con.X);
            if(!group.Contains(con.Y)) group.Add(con.Y);
        }
    }
