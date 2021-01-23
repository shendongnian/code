    public abstract class BoatFactory
    {       protected abstract void Initialize();
            protected  Wood Wood;
            protected  Axe Axe
            protected Boatmaker Boatmaker ;
            public Boat MakeBoat(Wood wood, Axe axe)
            {
                this.Wood = wood;
                this.Axe = axe;
                Initialize();
            }
            public Boat MakeBoat(Boatmaker maker)
            {
                this.Boatmaker = Boatmaker ;
                Initialize();
            }
            public Boat MakeBoat(Lake lake)
            {
                this.Lake = lake;
                Initialize();
            }
    }
    
    public class SmallBoatFactory : BoatFactory
    {
            protected override void Initialize()
            {
                // do customized init operations here
            }
    }
