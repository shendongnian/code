    var p1 = new Player();
    var p2 = new Player();
    var p3 = new Player();
    
    var team = new Team
    {
        Players = new List<Player>
        {
            p1,
            p2,
            p3
        },
        Captain = p3
    };
