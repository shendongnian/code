    abstract class Habitat
    {
        public abstract Animal ApexPredator();
    }
    class Savanna : Habitat
    {
        public override Lion ApexPredator()
        { ... }
    }
    class Ocean : Habitat
    {
        public override Shark ApexPredator()
        { ... }
    }
