    foreach (string str in db.FavoriteTalents.GroupBy(c => c.FavoriteID)
                           .Select(group => new
                           {
                              fID = @group.Key,
                              Count = @group.Count()
                           }).OrderBy(x => x.fID).Select(item => String.Format("{0} ---> {1}", item.fID, item.Count)))
                         //Or even better with string interpolation : item => $"{item.fID} ---> {item.Count}"
    {
         MessageBox.Show(str);
    }
