    public void Handle<StartGameCommand>()
    {
         var player = someEventSourcedPlayerRepository.GetOrCreateOrWhatever();
         player.assignRole(); // randomly assigns the role and creates event RoleAssigned
         someEventSourcedPlayerRepository.Save(); // saves events to db
    }
