        internal async Task<InMemoryRandomAccessStream> getImage(Uri uri)
        {
            try {
                var httpClient = new HttpClient();
                IBuffer iBuffer = await httpClient.GetBufferAsync(uri);
                byte[] bytes = iBuffer.ToArray();
                InMemoryRandomAccessStream ims = new InMemoryRandomAccessStream();
                DataWriter dataWriter = new DataWriter(ims);
                dataWriter.WriteBytes(bytes);
                await dataWriter.StoreAsync();
                ims.Seek(0);
                return ims;
            } catch (Exception e) { return null; }
        }
