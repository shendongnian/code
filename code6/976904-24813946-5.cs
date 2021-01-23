    class AccessPoint : IComparable<AccessPoint>
    {
      public string Name { get ; set ; }
      public int  Id { get ; set ; }
      public bool Value { get ; set ; }
      
      public int CompareTo( AccessPoint other )
      {
        int cc = other != null ? 0 : -1 ;
        if ( cc == 0 )
        {
          cc = String.Compare( this.Name , other.Name , StringComparison.Ordinal ) ;
        }
        if ( cc == 0 )
        {
          cc = this.Id.CompareTo( other.Id ) ;
        }
        return cc ;
      }
      public override string ToString()
      {
        return string.Format( "name={0}, id={1}, value={2}" , Name,Id,Value ) ;
      }
    }
