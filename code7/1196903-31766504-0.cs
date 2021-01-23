    public class Player
    {
     int currentHp = 100;
     int maxHp = 100;
     int atkPower = 20;
     int defense = 20;
     string playerName = "Ashe"
     
     public Player() {}
     public void TakeDamage(int damage)
     {
      currentHp = currentHp - damage;
     }
    }
    public class Enemy
    {
     int currentHp = 100;
     int maxHp = 100;
     int atkPower = 20;
     int defense = 20;
     string enemyName= "Rattata"
     public Enemy(){}
     public int AttackPlayer(Player player)
     {
       // all of your attack logic, pass in the player here
       player.TakeDamage(someAmountofDamage);
     }
    }
