        class PGPKeys
        {
            private long m_KeyId;
            private string m_PrivateKeyPath;
            private string m_PublicKeypath;
            private string m_Password;
            public PgpPublicKey m_PGPPublicKey { get; private set; }
            public PgpPrivateKey m_PGPPrivateKey { get; private set; }
            public PgpSecretKey m_PGPSecretKey { get; private set; }
    
    
            public PGPKeys(string public_key_path, string private_key_path, string password, long key_id)
            {
                if (!File.Exists(public_key_path))
                    throw new ArgumentNullException("Could not find the public key at" + public_key_path);
    
                if (!File.Exists(private_key_path))
                    throw new ArgumentNullException("Could not find the public key at" + private_key_path);
    
                if (String.IsNullOrEmpty(password))
                    throw new ArgumentNullException("The password must not be null");
    
                if (key_id == 0)
                    throw new ArgumentNullException("The password must not be null");
    
                m_KeyId = key_id;
    
                m_PGPPublicKey = GetPublicKey(public_key_path);
    
                m_PGPPrivateKey = GetPrivateKey(password, private_key_path);
              
            }
    
            private PgpPrivateKey GetPrivateKey(string password, string private_key_path)
            {
                PgpSecretKey secret_key = GetSecretKey(private_key_path);
                
                PgpPrivateKey private_key = secret_key.ExtractPrivateKey(password.ToCharArray());
    
                if (private_key == null)
                    return null;
    
                return private_key;
            }
    
            private PgpSecretKey GetSecretKey(string private_key_path)
            {
                PgpSecretKey secret_key = null; 
    
                using (Stream keyin = File.OpenRead(private_key_path))
                {
                    using (Stream private_key_Stream = PgpUtilities.GetDecoderStream(keyin))
                    {
                        PgpSecretKeyRingBundle secret_key_ring_bundle = new PgpSecretKeyRingBundle(private_key_Stream);
    
                         secret_key = GetLastSecretKey(secret_key_ring_bundle); 
                    }
                }
                return secret_key;
            }
    
            private PgpPublicKey GetPublicKey(string public_key_path)
            {
                PgpPublicKey public_key = null;
    
                using (Stream keyin = File.OpenRead(public_key_path))
                {
                    using (Stream public_key_stream = PgpUtilities.GetDecoderStream(keyin))
                    {
                        PgpPublicKeyRingBundle public_key_bundle = new PgpPublicKeyRingBundle(public_key_stream);
    
                        foreach (PgpPublicKeyRing public_key_ring in public_key_bundle.GetKeyRings())
                        {
                            foreach (PgpPublicKey key in public_key_ring.GetPublicKeys())
                            {
                                long modified_key_id = key.KeyId & 0x00000000FFFFFFFF;
    
                                if (modified_key_id == m_KeyId)
                                {
                                    public_key = key;
                                    break; 
                                }
                            }
                        }
    
                        if (public_key == null)
                            throw new Exception("The public key value is null");
                    }
                    return public_key;
                }
            }
    
            private PgpSecretKey GetLastSecretKey(PgpSecretKeyRingBundle secret_key_ring_bundle)
            {
    
                IEnumerable pgpKeyRings = secret_key_ring_bundle.GetKeyRings();
                
    
    
                return (from PgpSecretKeyRing kring in secret_key_ring_bundle.GetKeyRings()
                        select kring.GetSecretKeys().Cast<PgpSecretKey>().
                        LastOrDefault(k => k.IsSigningKey)).LastOrDefault(key => key != null); 
            }
        }
    
