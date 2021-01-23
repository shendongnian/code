    public string Int2Hex( int value )
    {
      if ( value <  0 ) throw new ArgumentOutOfRangeException("value") ;
      
      string result = "0x" + ( value == 0 ? "0" : ToHex( (uint) value ) ) ;
      return result ;
    }
    
    private string ToHex ( uint value )
    {
      string hex ;
      if ( value == 0 )
      {
        hex = "" ;
      }
      else
      {
        hex = ToHex( value / 16 )
            + "0123456789ABCDEF".Substring( value % 16 , 1 )
            ;
      }
      return hex ;
    }
