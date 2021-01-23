    public async Task<Certificate> GetClientCert()
            { 
                try {
                    Windows.Storage.StorageFile sampleFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Certificate/clients.pfx"));
                    IBuffer certBuffer = await Windows.Storage.FileIO.ReadBufferAsync(sampleFile);
                    String encodedCertificate = CryptographicBuffer.EncodeToBase64String(certBuffer);
                    Certificate crt = new Certificate(certBuffer);
                    return crt;
                }catch(Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
                return null;
            }
