        string Name { get; }
    }
    internal class PlanetBuilder
    {
        public string Name { get; set; }
        public IPlanet Commit()
        {
            return this;
        }
    }
