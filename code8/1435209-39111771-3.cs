    class GameEventHandler { 
        public void Handle(GameStartedEvent message) { 
            var randomRoles =_randomizer.GetRandomRoles(); 
            foreach(user in userAggregates) { 
                user.RoleAssign(new AssignRoleCommand(randomRoles[i] ));
            } 
        } 
    }
