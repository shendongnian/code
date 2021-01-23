    public static string DownloadString(string address) 
            {
                        string text;
                        using (var client = new WebClient()) 
                        {
                            text = client.DownloadString(address);
                        }
                        return text.Replace("<xml version=\"1.0\">", "").Replace("</xml>", "");
            }
