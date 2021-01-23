    class PGP
    {
        public PGP() { }
        
        /**
        * A simple routine that opens a key ring file and loads the first available key suitable for
        * encryption.
        *
        * @param in
        * @return
        * @m_out
        * @
        */
        public static PgpPublicKey ReadPublicKey(Stream inputStream)
        {
            inputStream = PgpUtilities.GetDecoderStream(inputStream);
            PgpPublicKeyRingBundle pgpPub = new PgpPublicKeyRingBundle(inputStream);
            //
            // we just loop through the collection till we find a key suitable for encryption, in the real
            // world you would probably want to be a bit smarter about this.
            //
            //
            // iterate through the key rings.
            //
            foreach (PgpPublicKeyRing kRing in pgpPub.GetKeyRings())
            {
                foreach (PgpPublicKey k in kRing.GetPublicKeys())
                {
                    if (k.IsEncryptionKey)
                        return k;
                }
            }
            
            throw new ArgumentException("Can't find encryption key in key ring.");
        }
        
        /**
        * Search a secret key ring collection for a secret key corresponding to
        * keyId if it exists.
        *
        * @param pgpSec a secret key ring collection.
        * @param keyId keyId we want.
        * @param pass passphrase to decrypt secret key with.
        * @return
        */
        private static PgpPrivateKey FindSecretKey(PgpSecretKeyRingBundle pgpSec, long keyId, char[] pass)
        {
            PgpSecretKey pgpSecKey = pgpSec.GetSecretKey(keyId);
            if (pgpSecKey == null)
                return null;
            
            return pgpSecKey.ExtractPrivateKey(pass);
        }
        
        /**
        * Decrypt the byte array passed into inputData and return it as
        * another byte array.
        *
        * @param inputData - the data to decrypt
        * @param keyIn - a stream from your private keyring file
        * @param passCode - the password
        * @return - decrypted data as byte array
        */
        public static byte[] Decrypt(byte[] inputData, Stream keyIn, string passCode)
        {
            byte[] error = Encoding.ASCII.GetBytes("ERROR");
            
            Stream inputStream = new MemoryStream(inputData);
            inputStream = PgpUtilities.GetDecoderStream(inputStream);
            MemoryStream decoded = new MemoryStream();
            
            try
            {
                PgpObjectFactory pgpF = new PgpObjectFactory(inputStream);
                PgpEncryptedDataList enc;
                PgpObject o = pgpF.NextPgpObject();
                
                //
                // the first object might be a PGP marker packet.
                //
                if (o is PgpEncryptedDataList)
                    enc = (PgpEncryptedDataList)o;
                else
                    enc = (PgpEncryptedDataList)pgpF.NextPgpObject();
                
                //
                // find the secret key
                //
                PgpPrivateKey sKey = null;
                PgpPublicKeyEncryptedData pbe = null;
                PgpSecretKeyRingBundle pgpSec = new PgpSecretKeyRingBundle(
                PgpUtilities.GetDecoderStream(keyIn));
                foreach (PgpPublicKeyEncryptedData pked in enc.GetEncryptedDataObjects())
                {
                    sKey = FindSecretKey(pgpSec, pked.KeyId, passCode.ToCharArray());
                    if (sKey != null)
                    {
                        pbe = pked;
                        break;
                    }
                }
                if (sKey == null)
                    throw new ArgumentException("secret key for message not found.");
                        
                    Stream clear = pbe.GetDataStream(sKey);
                    PgpObjectFactory plainFact = new PgpObjectFactory(clear);
                    PgpObject message = plainFact.NextPgpObject();
                    
                    if (message is PgpCompressedData)
                    {
                        PgpCompressedData cData = (PgpCompressedData)message;
                        PgpObjectFactory pgpFact = new PgpObjectFactory(cData.GetDataStream());
                        message = pgpFact.NextPgpObject();
                    }
                    if (message is PgpLiteralData)
                    {
                        PgpLiteralData ld = (PgpLiteralData)message;
                        Stream unc = ld.GetInputStream();
                        Streams.PipeAll(unc, decoded);
                    }
                    else if (message is PgpOnePassSignatureList)
                        throw new PgpException("encrypted message contains a signed message - not literal data.");
                    else
                        throw new PgpException("message is not a simple encrypted file - type unknown.");
                    
                    if (pbe.IsIntegrityProtected())
                    {
                        if (!pbe.Verify())
                            MessageBox.Show(null, "Message failed integrity check.", "PGP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(null, "Message integrity check passed.", "PGP Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(null, "No message integrity check.", "PGP Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return error;
                    }
                    
                    return decoded.ToArray();
                }
                catch (Exception e)
                {
                    if (e.Message.StartsWith("Checksum mismatch"))
                        MessageBox.Show(null, "Likely invalid passcode. Possible data corruption.", "Invalid Passcode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (e.Message.StartsWith("Object reference not"))
                        MessageBox.Show(null, "PGP data does not exist.", "PGP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (e.Message.StartsWith("Premature end of stream"))
                        MessageBox.Show(null, "Partial PGP data found.", "PGP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(null, e.Message, "PGP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Exception underlyingException = e.InnerException;
                    if (underlyingException != null)
                        MessageBox.Show(null, underlyingException.Message, "PGP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return error;
                }
            }
            
            /**
            * Encrypt the data.
            *
            * @param inputData - byte array to encrypt
            * @param passPhrase - the password returned by "ReadPublicKey"
            * @param withIntegrityCheck - check the data for errors
            * @param armor - protect the data streams
            * @return - encrypted byte array
            */
            public static byte[] Encrypt(byte[] inputData, PgpPublicKey passPhrase, bool withIntegrityCheck, bool armor)
            {
                byte[] processedData = Compress(inputData, PgpLiteralData.Console, CompressionAlgorithmTag.Uncompressed);
                
                MemoryStream bOut = new MemoryStream();
                Stream output = bOut;
                
                if (armor)
                    output = new ArmoredOutputStream(output);
                
                PgpEncryptedDataGenerator encGen = new PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag.Cast5, withIntegrityCheck, new SecureRandom());
                encGen.AddMethod(passPhrase);
                
                Stream encOut = encGen.Open(output, processedData.Length);
                
                encOut.Write(processedData, 0, processedData.Length);
                encOut.Close();
                
                if (armor)
                    output.Close();
                
                return bOut.ToArray();
            }
            
            private static byte[] Compress(byte[] clearData, string fileName, CompressionAlgorithmTag algorithm)
            {
                MemoryStream bOut = new MemoryStream();
                
                PgpCompressedDataGenerator comData = new PgpCompressedDataGenerator(algorithm);
                Stream cos = comData.Open(bOut); // open it with the final destination
                PgpLiteralDataGenerator lData = new PgpLiteralDataGenerator();
                
                // we want to Generate compressed data. This might be a user option later,
                // in which case we would pass in bOut.
                Stream pOut = lData.Open(
                cos,					// the compressed output stream
                PgpLiteralData.Binary,
                fileName,				// "filename" to store
                clearData.Length,		// length of clear data
                DateTime.UtcNow			// current time
                );
                
                pOut.Write(clearData, 0, clearData.Length);
                pOut.Close();
                
                comData.Close();
                
                return bOut.ToArray();
            }
        }
