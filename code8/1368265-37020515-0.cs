    public void SetupShip() {
      ship1 = new Ship("Olympic Countess");
    
      List<room> groupA = Enumerable
        .Range(1, 9)
        .Select(i => new room(5000, "A" + i))
        .ToList();
    
      List<room> groupB = Enumerable
        .Range(1, 9)
        .Select(i => new room(4000, "B" + i))
        .ToList();
    }
