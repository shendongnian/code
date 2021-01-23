    public class ChessField 
    {
       public bool b1;
       public bool b2;
       public int i1;
    }
    public List<ChessField> Method(ChessField c)
    {
        var result = new List<ChessField>();
        for (int i = 0;i<3;i++)
        {
           c.i1 = i;
           result.Add(c);
        }
        return result;
    }
