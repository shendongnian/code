    public ActionResult Complete(int id)
    {
        // Validate customer owns this order
        bool isValid = storeDB.Orders.Any(
            o => o.OrderId == id &&
            o.Username == User.Identity.Name);
        bool CheckOrderValue = storeDB.Orders.Any(o => o.OrderId == id && o.Total == 0);
        
        if (isValid && CheckOrderValue)
        {
            int idUser = 0;
            if (Request.IsAuthenticated)
            {
                var membership = (WebMatrix.WebData.SimpleMembershipProvider)Membership.Provider;
                idUser = membership.GetUserId(User.Identity.Name);
            }
    
            var musicaIDs = storeDB.OrderDetails.Where(o => o.OrderId == id).Select(o => o.MusicaId).ToList();
            foreach (var musicaId in musicaIDs)
            {
                var musicas = storeDB.Musicas.Where(x => x.MusicaId == musicaId)
                    .Select(x => new { x.Nome, x.NomeArtista, x.genero, x.path }).ToList().First();
                var y = new UsuarioMusica()
                {
                    UserId = idUser,
                    MusicaId = musicaID,
                    GeneroId = musicas.genero.GeneroId,
                    genero = musicas.genero,
                    Nome = musicas.Nome,
                    NomeArtista = musicas.NomeArtista,
                    path = musicas.path
                };
                if (ModelState.IsValid)
                {
                    storeDB.UsuarioMusicas.Add(y);
                }
            }
            storeDB.SaveChanges();
    
            return View(id);
        }
        else
        {
            return View("Error");
        }
    }
