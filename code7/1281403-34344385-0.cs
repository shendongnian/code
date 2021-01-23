    public class BitmapWrapper
    {
        private MemoryStream _stream = new MemoryStream () ;
        public Bitmap GetBitmap () 
        { 
            return new Bitmap ( _stream ) ; 
        }
        public void SetBitmap ( Bitmap value , ImageFormat format )
        {
            value.Save ( _stream, format ) ;
        }
    }
