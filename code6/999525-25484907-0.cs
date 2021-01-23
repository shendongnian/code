    public static byte[] GetByteArrayFromVersionFile(Web web,string fileVersionUrl)
            {
                WebClient wc = new WebClient();
                wc.UseDefaultCredentials = true;
                wc.Headers.Add("user-agent", " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
                byte[] content = wc.DownloadData(web.Url + "/" + fileVersionUrl);
                return content;
    
            }
