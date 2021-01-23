    [Serializable]
    public class Root{
        public Enemy[] enemies;
        public Root(Enemy[] enemies){
           this.enemies = enemies;
        }
    }
    [System.Serializable]
    public class Enemy
    {
       public int EnemyID; 
       public int EnemyHealth; 
       public EnemyType enemyType;
    }
    public enum EnemyType{ None, Soldiers, Boss }
