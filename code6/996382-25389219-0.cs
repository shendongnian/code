    class Struct
    {
      
      public static Struct Rehydrate( BinaryReader reader )
      {
        Struct instance = new Struct() ;
        
        instance.a = SubStruct.Rehydrate( reader ) ;
        
        for ( int i = 0 ; i < instance.b.Length ; ++i )
        {
          instance.b[i] = reader.ReadUInt16() ;
        }
        
        instance.c = reader.ReadInt32() ;
        
        return instance ;
        
      }
      
      public void Dehydrate( BinaryWriter writer )
      {
        this.a.Dehydrate( writer ) ;
        
        foreach( ushort value in this.b )
        {
          writer.Write( value ) ;
        }
        
        writer.Write( this.c ) ;
        
        return ;
      }
      
      public SubStruct a = null ;
      public ushort[]  b = {0,0,0};
      public int       c = 0 ;
      
    }
    class SubStruct
    {
      
      public static SubStruct Rehydrate( BinaryReader reader )
      {
        SubStruct instance = new SubStruct() ;
        
        for ( int i = 0 ; i < instance.d.Length ; ++i )
        {
          instance.d[i] = reader.ReadUInt16() ;
        }
        
        return instance ;
      }
      
      public void Dehydrate( BinaryWriter writer )
      {
        foreach( ushort value in this.d )
        {
          writer.Write(value) ;
        }
        return ;
      }
      
      public ushort[] d = {0,0,0} ;
      
    }
