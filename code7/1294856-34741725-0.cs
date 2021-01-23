HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("www.abc.com/start");
wr.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36";
HttpWebResponse authresponse = (HttpWebResponse)wr.GetResponse();
HttpWebRequest wr2 = (HttpWebRequest)WebRequest.Create("www.abc.com/prictureA");
foreach (Cookie c in authresponse.Cookies)
    wr2.CookieContainer.Add(new Cookie(c.Name, c.Value, c.Path, c.Domain));
HttpWebResponse imageresponse = (HttpWebResponse)wr2.GetResponse();
using (Stream str = imageresponse.GetResponseStream())
{
    byte[] buffer = new byte[str.Length];
    str.Read(buffer, 0, buffer.Length);
    //save image
    File.WriteAllBytes("prictureA.jpg", buffer);
}
