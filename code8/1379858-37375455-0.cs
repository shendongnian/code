    public static async Task<byte[]> ComputeMovieHash(string filename) {
        long filesize = 0;
        //Get File Size
        HttpWebRequest req = (HttpWebRequest) WebRequest.Create(filename);
        req.Method = "HEAD";
        var resp = await req.GetResponseAsync();
        filesize = resp.ContentLength;
        long lhash = filesize;
        //Get first 64K bytes
        byte[] firstbytes;
        using (HttpClient client = new HttpClient()) {
            client.DefaultRequestHeaders.Add("Range", "bytes=0-65535");
            using (HttpResponseMessage response = await client.GetAsync(filename)) {
                Debug.WriteLine("getting first bytes (bytes=0-65535)");
                firstbytes = await response.Content.ReadAsByteArrayAsync();
            }
        }
        for (int i = 0; i < firstbytes.Length; i += sizeof (long)) {
            lhash += BitConverter.ToInt64(firstbytes, i);
        }
        //Get last 64K bytes
        byte[] lastbytes;
        using (HttpClient client = new HttpClient()) {
            client.DefaultRequestHeaders.Add("Range", "bytes=" + Math.Max(filesize - 65536, 0) + "-" + filesize);
            using (HttpResponseMessage response = await client.GetAsync(filename)) {
                Debug.WriteLine("getting last bytes (" + "bytes=" + (filesize - 65536) + "-" + filesize + ")");
                lastbytes = await response.Content.ReadAsByteArrayAsync();
            }
        }
        for (int i = 0; i < lastbytes.Length; i += sizeof (long)) {
            lhash += BitConverter.ToInt64(lastbytes, i);
        }
        //Return result
        byte[] result = BitConverter.GetBytes(lhash);
        Array.Reverse(result);
        return result;
    }
