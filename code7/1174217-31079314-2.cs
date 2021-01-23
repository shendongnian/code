    class OffsetStreamDecorator : Stream
    {
      private readonly Stream instance ;
      private readonly long       offset   ;
      
      public static Stream Decorate( Stream instance )
      {
        if ( instance == null ) throw new ArgumentNullException("instance") ;
        
        FileStream decorator= new OffsetStreamDecorator( instance ) ;
        return decorator;
      }
      
      private OffsetStreamDecorator( FileStream instance )
      {
        this.instance = instance ;
        this.offset   = instance.Position ;
      }
      
      #region override methods and properties pertaining to the file position/length to transform the file positon using the instance's offset
      
      public override long Length
      {
        get { return instance.Length - offset ; }
      }
      
      public override void SetLength( long value )
      {
        instance.SetLength( value + offset );
      }
      
      public override long Position
      {
        get { return instance.Position - this.offset         ; }
        set {        instance.Position = value + this.offset ; }
      }
      
      // etc.
      
      #endregion
      
      #region override all other methods and properties as simple pass-through calls to the decorated instance.
      
      public override IAsyncResult BeginRead( byte[] array , int offset , int numBytes , AsyncCallback userCallback , object stateObject )
      {
        return instance.BeginRead( array , offset , numBytes , userCallback , stateObject );
      }
      
      public override IAsyncResult BeginWrite( byte[] array , int offset , int numBytes , AsyncCallback userCallback , object stateObject )
      {
        return instance.BeginWrite( array , offset , numBytes , userCallback , stateObject );
      }
      
      // etc.
      
      #endregion
      
    }
