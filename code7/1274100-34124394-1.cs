    public static class SimpleByteCipher
        {
    
            public static byte[] EncryptStringToByteArray( string data , string password , uint seed)
            {
                byte[] bytes = Encoding.ASCII.GetBytes( data );
                byte[] passwordBytes = Encoding.ASCII.GetBytes( password );
                int passwordShiftIndex = 0;
                for( int i = 0; i < bytes.Length; i++ )
                {
                    bytes[ i ] = ( byte )( bytes[ i ] + passwordBytes[ passwordShiftIndex ] + seed );
                    passwordShiftIndex = ( passwordShiftIndex + 1 ) % passwordBytes.Length;
                }
                return bytes;
            }
    
            public static string DecryptByteArrayToString( byte[] data , string password , uint seed)
            {
                byte[] bytes = data;
                byte[] passwordBytes = Encoding.ASCII.GetBytes( password );
                int passwordShiftIndex = 0;
                for( int i = 0; i < bytes.Length; i++ )
                {
                    bytes[ i ] = ( byte )( bytes[ i ] - passwordBytes[ passwordShiftIndex ] - seed );
                    passwordShiftIndex = ( passwordShiftIndex + 1 ) % passwordBytes.Length;
                }
                return Encoding.ASCII.GetString( bytes );
            }
        }
