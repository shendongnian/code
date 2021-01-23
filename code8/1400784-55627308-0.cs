     public void SendCommand( string command , Action<string> onDataRecevied )
        {
            if ( BthSocket.IsConnected )
            {
                byte[] cmd = Encoding.ASCII.GetBytes( command + " \r" );
                BthSocket.OutputStream.Write( cmd , 0 , cmd.Length );
                BthSocket.OutputStream.Flush();
                ReadData( out string d );
                if ( d != "" )
                {
                    onDataRecevied( d );
                }
            }
        }
