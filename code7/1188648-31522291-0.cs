    public enum DirectionType{ Right, Left };
    public class Enemy
    {
        public DirectionType Direction{ get; set; }
        public void HoneInOnHero()
        {
            //Hero's function can help determine position relative to the enemy.
            this.Direction = Hero.GetRelativeDirection(this);
        }
    }
    var enemy = new Enemy();
    enemy.Direction = DirectionType.Left;
    //or...
    if(attackMode)
        enemy.HoneInOnHero();
