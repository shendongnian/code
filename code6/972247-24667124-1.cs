    while (playerHealth > 0 && monsterHealth > 0)
    {
        bool playerAct = askAction();
        if (playerAct == true)// User attacks
        {
            monsterHealth = monsterHealth - playerAtk;
            if (monsterHealth <= 0)
            {
                Console.WriteLine(monsterName + " falls to the ground, defeated. Congradulation, " + name + "!");
            }
            else
            {
                Console.WriteLine(monsterName + " takes a mighty swing back at you!");
                playerHealth = playerHealth - monsterAtk;
            }
        }                
        else// User defends
        {
            playerHealth = playerHealth - defendAtk;
            if (playerHealth <= 0)
            {
                Console.WriteLine(monsterName + " has defeated you!");
            }
            else
            {
                Console.WriteLine(monsterName + " swings at you. It glances off your defenses.");
            }
        }               
    }
