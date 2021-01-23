    class Game
    {
         private readonly Horse horse;
         private int money;
         // more things
    
         public Game(Horse horse, int money)
         {             
            this.horse = horse;
            this.money = money;
         }
         public bool IsOver
         {
            get { return horse.IsDead(); }
         }
        
    }
