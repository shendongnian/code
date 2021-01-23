    static class Commands
    {
        // create a command to move a piece
        public static Action MovePiece(Piece piece, int x, int y)
        {
            return () => piece.MoveTo(x, y);
        }
    }
    class Program
    {
        public static Main(string[] args)
        {
            // ui or ai creates command
            var piece = new Piece();
            var command =  Commands.MovePiece(piece, 3, 4);
    
            // chess engine invokes it
            command();
        }
    }
