    CookieContainer cookies = new CookieContainer();
    
    private void button1_Click(object sender, EventArgs e)
    {
        // do a get to have the session cookie
        var wr = (HttpWebRequest) WebRequest.Create("http://www.abarcode.net/online.aspx");
        wr.CookieContainer = cookies;
        wr.Method = "GET";
        var stream =  wr.GetResponse().GetResponseStream();
        using(var sr = new StreamReader(stream))
        {
            // debug
            Debug.WriteLine(sr.ReadToEnd());
        }
        // get the image
        var imageReq = (HttpWebRequest)WebRequest.Create(
            String.Format(
                "http://www.abarcode.net/barcode.aspx?value={0}&type=EAN13", 
                textBox1.Text));
        // this makes if you get their watermark in the barcode or not
        imageReq.Referer = "http://www.abarcode.net/online.aspx?barcode=EAN13";
        imageReq.CookieContainer = cookies;
        imageReq.Method = "GET";
        // get the image stream
        stream = imageReq.GetResponse().GetResponseStream();
    
        // create the bitmap.
        pictureBox1.Image =  Bitmap.FromStream(stream);
    }
