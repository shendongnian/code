    public struct  NRowsColumns: Point
    {
       public int NRows {get {return base.x;}}
       public int NColumns {get {return base.y;}}
       public NRowsColumns(int nRows, int nColumns) 
          : base(nRows, nColumns)
       {
       }
    }
