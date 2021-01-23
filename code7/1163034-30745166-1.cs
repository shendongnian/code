    public char [ ] encryptCBC ( char [ ] plain, char [ ] password, char [ ] iv )
    {
        char [ ] ciphertext = new char [ 8 ];
        for ( int i = 0; i < 8; i ++ )
        {
                ciphertext [ i ] = plain ^ iv;
                ciphertext [ i ] ^= password;
        }
        return ciphertext;
    }
    public char [ ] decryptCBC ( char [ ] ciphertext, char [ ] password, char [ ] iv )
    {
        char [ ] plaintext = new char [ 8 ];
        for ( int i = 0; i < 8; i ++ )
        {
                plaintext [ i ] = ciphertext ^ password;
                plaintext [ i ] ^= iv;
        }
        return plaintext;
    }
