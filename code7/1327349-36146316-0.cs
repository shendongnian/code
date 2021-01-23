            private static RSACryptoServiceProvider DecodeRsaPrivateKey(string priKey)
            {
                var privkey = Convert.FromBase64String(priKey);
                byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;
    
                // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
                var mem = new MemoryStream(privkey);
                var binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
                try
                {
                    var twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();        //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();       //advance 2 bytes
                    else
                        return null;
                    twobytes = binr.ReadUInt16();
                    if (twobytes != 0x0102) //version number
                        return null;
                    var bt = binr.ReadByte();
                    if (bt != 0x00)
                        return null;
    
                    //------  all private key components are Integer sequences ----
                    var elems = GetIntegerSize(binr);
                    MODULUS = binr.ReadBytes(elems);
    
                    elems = GetIntegerSize(binr);
                    E = binr.ReadBytes(elems);
    
                    elems = GetIntegerSize(binr);
                    D = binr.ReadBytes(elems);
    
                    elems = GetIntegerSize(binr);
                    P = binr.ReadBytes(elems);
    
                    elems = GetIntegerSize(binr);
                    Q = binr.ReadBytes(elems);
    
                    elems = GetIntegerSize(binr);
                    DP = binr.ReadBytes(elems);
    
                    elems = GetIntegerSize(binr);
                    DQ = binr.ReadBytes(elems);
    
                    elems = GetIntegerSize(binr);
                    IQ = binr.ReadBytes(elems);
    
                    // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                    var rsa = new RSACryptoServiceProvider();
                    var rsAparams = new RSAParameters
                    {
                        Modulus = MODULUS,
                        Exponent = E,
                        D = D,
                        P = P,
                        Q = Q,
                        DP = DP,
                        DQ = DQ,
                        InverseQ = IQ
                    };
                    rsa.ImportParameters(rsAparams);
                    return rsa;
                }
                catch (Exception e)
                {
                    LogHelper.Logger.Error("DecodeRsaPrivateKey failed", e);
                    return null;
                }
                finally
                {
                    binr.Close();
                }
            }
            
            private static int GetIntegerSize(BinaryReader binary)
            {
                byte binaryReadByte = 0;
                var count = 0;
                binaryReadByte = binary.ReadByte();
                if (binaryReadByte != 0x02)        //expect integer
                    return 0;
                binaryReadByte = binary.ReadByte();
                if (binaryReadByte == 0x81)
                {
                    count = binary.ReadByte(); // data size in next byte
                }
                else
                {
                    if (binaryReadByte == 0x82)
                    {
                        var highbyte = binary.ReadByte();
                        var lowbyte = binary.ReadByte();
                        byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                        count = BitConverter.ToInt32(modint, 0);
                    }
                    else
                    {
                        count = binaryReadByte; // we already have the data size
                    }
                }
                while (binary.ReadByte() == 0x00)
                {    //remove high order zeros in data
                    count -= 1;
                }
                binary.BaseStream.Seek(-1, SeekOrigin.Current);        //last ReadByte wasn't a removed zero, so back up a byte
                return count;
            }
