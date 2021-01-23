    public void ReadData( out string data )
        {
            StringBuilder res = new StringBuilder();
            try
            {
                byte b = 0;
                // read until '>' arrives OR end of stream reached
                char c;
                // -1 if the end of the stream is reached
                while ( ( b = ( ( byte )BthSocket.InputStream.ReadByte() ) ) > -1 )
                {
                    c = ( char )b;
                    if ( c == '>' ) // read until '>' arrives
                    {
                        break;
                    }
                    res.Append( c );
                }
            }
            catch ( Exception e )
            {
                System.Console.WriteLine( e.ToString() );
            }
          data = res.ToString().Replace( "SEARCHING" , "" );
            /*
             * Data may have echo or informative text like "INIT BUS..." or similar.
             * The response ends with two carriage return characters. So we need to take
             * everything from the last carriage return before those two (trimmed above).
             */
            
            data = data.Replace( "\\s" , "" );
        }
