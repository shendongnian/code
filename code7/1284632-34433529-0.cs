     foreach (string str in db.FavoriteTalents.GroupBy(c => c.FavoriteID)
                .Select(group => new
                {
                    fID = @group.Key,
                    Count = @group.Count()
                })
                .OrderBy(x => x.fID).Select(item => String.Format("{0} ---> {1}", item.fID, item.Count)))
            {
                MessageBox.Show(str); // 1  --> 3 and 9 --> 2
            }
