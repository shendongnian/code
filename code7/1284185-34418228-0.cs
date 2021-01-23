    public static string DownloadString(this string link)
    {
        WebClient wc = null;
        string s = null;
        try
        {
            wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            byte[] b = wc.DownloadData(link);
            MemoryStream output = new MemoryStream();
            using (GZipStream g = new GZipStream(new MemoryStream(b), CompressionMode.Decompress))
            {
                g.CopyTo(output);
            }
            return Encoding.UTF8.GetString(output.ToArray());
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (wc != null)
            {
                wc.Dispose();
            }
        }
        return null;
    }
