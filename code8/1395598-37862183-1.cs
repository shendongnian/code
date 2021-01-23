    foreach (var i in invList)
    {
      if (DateTime.Compare(i.InviteDate.Date.AddDays(7).Date, dt) < 0)
      {
         hh.Invites.Remove(i);
         db.Entry(i).State = EntityState.Deleted;
      }
    }
