    public byte[] Protect(byte[] clearData) {
            // The entire operation is wrapped in a 'checked' block because any overflows should be treated as failures.
            checked {
 
                // These SymmetricAlgorithm instances are single-use; we wrap it in a 'using' block.
                using (SymmetricAlgorithm encryptionAlgorithm = _cryptoAlgorithmFactory.GetEncryptionAlgorithm()) {
                    // Initialize the algorithm with the specified key and an appropriate IV
                    encryptionAlgorithm.Key = _encryptionKey.GetKeyMaterial();
 
                    if (_predictableIV) {
                        // The caller wanted the output to be predictable (e.g. for caching), so we'll create an
                        // appropriate IV directly from the input buffer. The IV length is equal to the block size.
                        encryptionAlgorithm.IV = CryptoUtil.CreatePredictableIV(clearData, encryptionAlgorithm.BlockSize);
                    }
                    else {
                        // If the caller didn't ask for a predictable IV, just let the algorithm itself choose one.
                        encryptionAlgorithm.GenerateIV();
                    }
                    byte[] iv = encryptionAlgorithm.IV;
 
                    using (MemoryStream memStream = new MemoryStream()) {
                        memStream.Write(iv, 0, iv.Length);
 
                        // At this point:
                        // memStream := IV
 
                        // Write the encrypted payload to the memory stream.
                        using (ICryptoTransform encryptor = encryptionAlgorithm.CreateEncryptor()) {
                            using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write)) {
                                cryptoStream.Write(clearData, 0, clearData.Length);
                                cryptoStream.FlushFinalBlock();
 
                                // At this point:
                                // memStream := IV || Enc(Kenc, IV, clearData)
 
                                // These KeyedHashAlgorithm instances are single-use; we wrap it in a 'using' block.
                                using (KeyedHashAlgorithm signingAlgorithm = _cryptoAlgorithmFactory.GetValidationAlgorithm()) {
                                    // Initialize the algorithm with the specified key
                                    signingAlgorithm.Key = _validationKey.GetKeyMaterial();
 
                                    // Compute the signature
                                    byte[] signature = signingAlgorithm.ComputeHash(memStream.GetBuffer(), 0, (int)memStream.Length);
 
                                    // At this point:
                                    // memStream := IV || Enc(Kenc, IV, clearData)
                                    // signature := Sign(Kval, IV || Enc(Kenc, IV, clearData))
 
                                    // Append the signature to the encrypted payload
                                    memStream.Write(signature, 0, signature.Length);
 
                                    // At this point:
                                    // memStream := IV || Enc(Kenc, IV, clearData) || Sign(Kval, IV || Enc(Kenc, IV, clearData))
 
                                    // Algorithm complete
                                    byte[] protectedData = memStream.ToArray();
                                    return protectedData;
                                }
                            }
                        }
                    }
                }
            }
        }
