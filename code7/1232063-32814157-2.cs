    public class Formatter : Dictionary<string, Unit>
    {
        public Formatter()
        {
            Add("Mass", new Unit { Name = "Mass", Display = "Kg", Factor = 1 });
            Add("MassPU", new Unit { Name = "MassPU", Display = "Kg/m", Factor = 0.001 });
        }
    }
