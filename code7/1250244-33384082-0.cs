    public bool BIO_Write(byte[] data)
    {
        if (Inited)
        {
            Wrapper.BIO_write(BIOR, data, data.Length);
            if (isServer(SSL_method))
            {
                // If this session is in server mode we need to call SSL_read()
                // every time we write the reading BIO
                readFromSSL();              
            }
            else
            {
                // If this session is a client
                if (HandShakeIsDone)
                {
                    // then we should call SSL_read() only after
                    // successful handshaking!
                    readFromSSL();
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }
