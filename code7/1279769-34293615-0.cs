    public void Decrypt(Stream encrypted_stream, string output_path)
            {
                encrypted_stream = PgpUtilities.GetDecoderStream(encrypted_stream);
    
                PgpEncryptedDataList encrypted_data_list;
    
                PgpObjectFactory pgp_factory = new PgpObjectFactory(encrypted_stream);
    
                PgpObject pgp_object = pgp_factory.NextPgpObject();
    
                if (pgp_object is PgpEncryptedDataList)
                {
                    encrypted_data_list = (PgpEncryptedDataList)pgp_object;
                }
                else
                {
                    encrypted_data_list = (PgpEncryptedDataList)pgp_factory.NextPgpObject();
                }
    
                PgpPrivateKey private_key = m_PGPKeys.m_PGPPrivateKey;
    
                PgpPublicKeyEncryptedData public_encrypted_data = null;
    
                IEnumerable encryptedDataObjects = encrypted_data_list.GetEncryptedDataObjects(); 
    
                foreach (PgpPublicKeyEncryptedData pked in encrypted_data_list.GetEncryptedDataObjects())
                {
                    if (private_key != null)
                    {
                        public_encrypted_data = pked;
                        break;
                    }
                }
    
                Stream clear_stream = public_encrypted_data.GetDataStream(private_key);
    
                PgpObjectFactory plain_factory = new PgpObjectFactory(clear_stream);
    
                PgpObject message = plain_factory.NextPgpObject();
    
                if (message is PgpCompressedData)
                {
                    PgpObjectFactory compressed_data_factory_object = HandleCompressedPGPData(ref message);
    
                    if (message is PgpOnePassSignatureList)
                    {
                        message = HandleOnePassSingnatureList(output_path, message, compressed_data_factory_object);
                    }
                }
    
                PgpLiteralData literal_data = (PgpLiteralData)message;
                Stream output_stream = File.Create(@"C:\PGP\Result7");
                Stream unencrypted_stream = literal_data.GetInputStream();
                Streams.PipeAll(unencrypted_stream, output_stream);
            }
    
            private static PgpObject HandleOnePassSingnatureList(string output_path, PgpObject message, PgpObjectFactory compressed_data_factory_object)
            {
                message = compressed_data_factory_object.NextPgpObject();
                // Literal Data packet contains the body of a message; data that is
                //not to be further interpreted.
                PgpLiteralData signature_literal_data = null;
    
                signature_literal_data = (PgpLiteralData)message;
    
                Stream signature_output_stream = File.Create(output_path + "\\" + signature_literal_data.FileName);
    
                Stream unencrypted_signature_stream = signature_literal_data.GetInputStream();
    
                Streams.PipeAll(unencrypted_signature_stream, signature_output_stream);
                return message;
            }
    
            private static PgpObjectFactory HandleCompressedPGPData(ref PgpObject message)
            {
    
                PgpCompressedData compressed_data = (PgpCompressedData)message;
    
                Stream compressed_data_in = compressed_data.GetDataStream();
    
                PgpObjectFactory compressed_data_factory_object = new PgpObjectFactory(compressed_data_in);
    
                message = compressed_data_factory_object.NextPgpObject();
                return compressed_data_factory_object;
            }
    
    
 
  
