    var q = db.FavoriteTalents
				.Where(r => r.Favorite.CDUserID == UserID || r.Favorite.CDUserID == 0)
				.GroupBy(t => t.FavoriteID)
				.Select(r => new { FavoriteID = r.FavoriteID, Count = r.Select(grouped => grouped.TalentID).Distinct.Count() })
				.ToArray();
