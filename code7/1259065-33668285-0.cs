    public abstract class BoatFactory
        {
            protected abstract BoatFactory Initialize();
           
            public BoatFactory MakeSmallBoat(Wood wood, Axe axe)
            {
                return Initialize();
            }
            public BoatFactory MakeSmallBoat(Boatmaker maker)
            {
                return Initialize();
            }
            public BoatFactory MakeSmallBoat(Lake lake)
            {
                return Initialize();
            }
        }
    
        public class SmallBoatFactory : BoatFactory
        {
            protected override BoatFactory Initialize()
            {
                // do customized init operations here
            }
        }
