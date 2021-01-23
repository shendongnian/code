    public Bitmap getImageFromURL(string sURL)
        {
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(sURL);
            Request.Method = "GET";
            Request.UseDefaultCredentials = true;
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(Response.GetResponseStream());
            Response.Close();
            return bmp;
        }
