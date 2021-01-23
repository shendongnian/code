    public void SetupShip()
        {
            ship1 = new Ship("Olympic Countess");
            ArrayList groupA = new ArrayList();
            ArrayList groupB = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                groupA.Add(new room(5000, "A" + (i + 1)));
                groupB.Add(new room(4000, "B" + (i + 1)));
            }
            
        }
