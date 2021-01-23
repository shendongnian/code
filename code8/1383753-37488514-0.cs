    var song = _songService.GetSong(editSongDto.Song.Id);
    var buyLinks = song.BuyLinks.ToList();
    ...
  
    foreach (var buyLinkDto in editSongDto.BuyLinkDtos)
    {
        var buyLink = buyLinks.SingleOrDefault(m => m.Id != 0 && m.Id == buyLinkDto.Id);
        
        // New BuyLink
        if (buyLink == null)
        {
            buyLink = new BuyLink { BuyLinkUrl = buyLinkDto.BuyLinkUrl };
            song.BuyLinks.Add(buyLink);
        }
        // Existing BuyLink
        else
        {
            buyLink.BuyLinkUrl = buyLinkDto.BuyLinkUrl;
        }
    }
