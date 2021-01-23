    public class ChessPiece
    {
        public ColorEnum Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public virtual bool IsAValidMovement(int x, int y)
        {
            // base common logic
        }
    }
    public class QueenPiece : ChessPiece
    {
        public override bool IsAValidMovement(int x, int y)
        {
            if (base.IsAValidMovement(x, y))
            {
                // specific logic
            }
        }
    }
