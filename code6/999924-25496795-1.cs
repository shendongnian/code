    private static void MobAttacksPlayer(Objects.Creature inMob)
    {    
        var totalDamage = 0;
        foreach (var attack in inMob.creatureAttacks) 
        {
            var attackDamage = attack.RollDamage();
            Console.Write(attackDamage);
            totalDamage += attackDamage;
        }
        Console.Write(totalDamage);
    }
