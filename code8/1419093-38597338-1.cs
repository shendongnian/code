    public interface IPlanet
    {
        string Name { get; }
    }
    internal class PlanetBuilder : IPlanet
    {
        public string Name { get; set; }
        public IPlanet Commit()
        {
            return this;
        }
    }
