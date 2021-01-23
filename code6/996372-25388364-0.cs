    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    Player players[] = new Player[11];
    
    players[0] = new Player(){ Name = player1.Text, Score = int.Parse( score1.Text ) };
