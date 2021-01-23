    public static void add(int id, int amount)
    {
        for (int i = 0; i < Ship_Builder.Player.invCount; i++)
        {
            if (Ship_Builder.Player.inv[i, 0] != id)
            {
                if (Ship_Builder.Player.inv[i, 0] == 0)
                {
                    Ship_Builder.Player.inv[i, 0] = id; 
                    Ship_Builder.Player.inv[i, 1] = amount;
                    Ship_Builder.Player.invCount++; 
                    continue;
                }
            }
            else
            {
                Ship_Builder.Player.inv[i, 1] += amount;
            }
        }
    }
