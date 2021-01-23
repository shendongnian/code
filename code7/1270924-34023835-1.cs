    public class Compound
    {
        public Compound(IPart part1, IPart part2)
        {
            Part1 = part1;
            Part2 = part2;
        }
    
        public IPart Part1 { get; private set; }
        public IPart Part2 { get; private set; }
    }
