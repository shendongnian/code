    public interface IPart {
        Guid Id { get; }
        void SwitchOn();
        void Execute();
    }
    
    public class Compound
    {
        private readonly IPart _part1;
        private readonly IPart _part2;
    
        public Compound(IPart part1, IPart part2)
        {
            _part1 = part1;
            _part2 = part2;
        }
    
        public Guid Part1Id { get { return _part1.Id; } }
        public void Part1SwitchOn() { _part1.SwitchOn(); }
        public void DoPart1Specific() { _part1.Execute(); }
    
        public Guid Part2Id { get { return _part2.Id; } }
        public void Part2SwitchOn() { _part2.SwitchOn(); }
        public void DoPart2Specific() { _part2.Execute(); }
    }
