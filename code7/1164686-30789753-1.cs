    // Get the contents of the stream.
    byte[] byKey = oMS.ToArray ();
    
    fixed ( byte *pBytes = byKey )
    {
        char* pChars = (char*) pBytes;
        var oSecStr = new SecureString ( pChars, byKey.Length / 2 );
            
        // Clear byte array and stream
        Array.Clear ( byKey, 0, byKey.Length );
        oMS.Seek ( 0, SeekOrigin.Begin );
        oMS.Write ( byKey, 0, byKey.Length );
    }
