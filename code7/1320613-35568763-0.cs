    try
    {
        WebClient wc = new WebClient();
        wc.Headers.Add(HttpRequestHeader.Referer, "http://www.munifilings.com/munifilings/speedSearch.do?affiliateId=97&memberId=MPSNQTVY1CGKAEI&cusip=738855HJ7");
        wc.DownloadFile("http://munifilings.com/pdfs/0/k36062.pdf", @"D:\\pathToFile");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.ReadLine();
