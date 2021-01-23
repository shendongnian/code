    var p1 = (from p in db.Players
                     where p.PlayerName == DropDownListPlayer1.SelectedItem.Text
                     select new Player {PlayerName = p.PlayerName,
                                        PlayerId = p.PlayerId}
             ).FirstOrDefault();
           
    if(p1 != null)
    {
         players.Add(p1);
    }
