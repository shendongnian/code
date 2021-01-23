     foreach (var item in db.Pos.Select(l => l.Fecha).Distinct())
        {
            string dateday = item.ToString("yyyy-MM-dd");
            string lines = dateday.Split('-')[0];
            listItem2.Add(item.ToString());
        }
