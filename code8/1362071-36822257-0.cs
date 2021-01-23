        public class Kralica : Figure
        {
            protected Tuple<int, int> Position {get; set;}
            public Kralica(FigureDefinition definition) : base(definition)
            {
            }
        
            protected override List<Tuple<int, int>> GetValidTurns()
            {
                //here i want to combine the 2 methods GetValidTurns from the bishop class and the rook class
            }
        	
        	protected void AddDiagonalMoves(List<Tuple<int, int>> moves)
        	{
        		diagonalMoves = new List<Tuple<int, int>>();
        
        		// calculate diagonal moves from my piece position which should be a member property here
        		
        		moves.AddRange(diagonalMoves);
        	}
        }
    
    
    public class Kralica : Figure
    {
        public Kralica(FigureDefinition definition) : base(definition)
        {
        }
    
        protected override List<Tuple<int, int>> GetValidTurns()
        {
            var movesThisTurn = new List<Tuple<int, int>>(); 
            //here i want to combine the 2 methods GetValidTurns from the bishop class and the rook class
            base.AddDiagonalMoves(movesThisTurn);
            base.AddLinearMoves(movesThisTurn);
    
        }
    }
