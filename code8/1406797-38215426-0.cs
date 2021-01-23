    public static string GetHash( string caminho ) {
            const int bytesToRead = 64 * 1024;
            byte[] buffer = new byte[bytesToRead * 2];
            MD5 md5 = new MD5CryptoServiceProvider( );
            using( var md52 = MD5.Create( ) ) {
                using( var stream = new FileStream( caminho, FileMode.Open, FileAccess.Read ) ) {
                    for( int i = 0; i < bytesToRead; i++ ) {
                        buffer[i] = (byte)stream.ReadByte( );
                    }
                    stream.Seek( -bytesToRead, SeekOrigin.End );
                    for( int i = bytesToRead; i < bytesToRead * 2; i++ ) {
                        buffer[i] = (byte)stream.ReadByte( );
                    }
                    return BitConverter.ToString( md52.ComputeHash( buffer ) ).Replace( "-", "" ).ToLower( );
                }
            }          
        }
