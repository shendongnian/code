    System.Net.WebRequest request = System.Net.WebRequest.Create("http://url");
    using (System.Net.WebResponse response = ((System.Net.WebResponse)request.GetResponse()))
    using (System.IO.Stream stream = response.GetResponseStream())
    {
       System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");
    }
