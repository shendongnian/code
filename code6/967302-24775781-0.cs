     //Convert stuff to have to right encoding in a char array
                var myCommand = stamp + ((stamp.Length > 0) ? " " : "") + command + "\r\n";
                var bytesUtf8 = Encoding.UTF8.GetBytes(myCommand);
                var commandCharArray = Encoding.UTF8.GetString(bytesUtf8).ToCharArray();
    
    #if !PocketPC
                if (this._sslStream != null)
                {
    
    
                    this._sslStream.Write(System.Text.Encoding.UTF8.GetBytes(commandCharArray));
                }
                else
                {
                    base.GetStream().Write(System.Text.Encoding.UTF8.GetBytes(commandCharArray), 0, commandCharArray.Length);
                }
    #endif
    
    #if PocketPC
                            base.GetStream().Write(System.Text.Encoding.UTF8.GetBytes(commandCharArray), 0, commandCharArray.Length);
    #endif
