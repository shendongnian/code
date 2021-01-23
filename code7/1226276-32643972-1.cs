    public string GetThumbnailsUrl(string url)// this url is your youtube video url
    {
        string imgurl = "";
        if (url != "")
        {
            if (!url.ToLower().Contains("embed/"))//if not an embed URL
            {
                string v = url;
                if (url.Contains("?"))
                {
                    v = v.Substring(v.LastIndexOf("v=") + 2);
                    if (v.Contains("&"))
                        v = v.Substring(0, v.LastIndexOf("&"));
                }
                else
                {
                    v = v.Substring(v.LastIndexOf("v/") + 2);
                }
                int i = 0;
                try
                {
                    i = Convert.ToInt32(ConfigurationManager.AppSettings["ImageSize"].Trim());//ImageSize contains the size of image.... the value is like 0,1,2,3.....
                }
                catch { i = 0; }
                imgurl = "http://img.youtube.com/vi/" + v + "/" + i + ".jpg";
            }
            else//For embed URL
            {
                string[] sep = new string[1] { "embed/" };
                string[] ss = url.Split(sep, StringSplitOptions.None);
                string key = ss[ss.Length - 1];
                int i = 0;
                try
                {
                    i = Convert.ToInt32(ConfigurationManager.AppSettings["ImageSize"].Trim());
                }
                catch { i = 0; }
                imgurl = "http://img.youtube.com/vi/" + key + "/" + i + ".jpg";
            }
        }
        return imgurl;
    }
