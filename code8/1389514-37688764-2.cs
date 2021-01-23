    _blogService.Insert(new Blog()
    {
       Titel = vm.Titel,
       Beschrijving = vm.Beschrijving,
       Content = (vm.Actie.ToLower() == "publiceer" ? true : false),
       Verwijderd = false,
       AuteurId = User.Identity.GetUserId()
    });
