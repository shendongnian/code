    public class Kralica : Figure
    {
        public Kralica(FigureDefinition definition) : base(definition)
        {
        }
        protected override List<Move> GetValidTurns()
        {
            return moves;
        }
        readonly List<Move> moves = new List<Move> {new Diagonal(), new Orthongonal()};
    }
