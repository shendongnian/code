    using (WebClient page = new WebClient())
    {
        try
        {
            byte[] result = page.DownloadData(url);
            for(int i=0;i<result.Length;i++)
            {
                result[i] ^= 0x42;
            }
            File.WriteAllBytes(filename, result);
        }
        catch (WebException er)
        {
            MessageBox.Show(er.ToString());
                    
        }
    }
