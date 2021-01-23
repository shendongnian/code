    public class TetrisBlock
    {
      public Point Location{get; set}
      public double Angle{get; set}
      public int[,] DefinitionPoints{get; set}
      
      public static CheckCollision( IList<TetrisBlock> source )
      {
        ..calculation here..
      }
    }
