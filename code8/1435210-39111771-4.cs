    class Game {
        public void startGame () {
            this.apply(GameStarted());
            var randomRoles =_randomizer.GetRandomRoles(); 
            foreach(userId in this.players) {
                this.apply(RoleAssigned(userId, randomRoles[i]);
            }
        }
    }
