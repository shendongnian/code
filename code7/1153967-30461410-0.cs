    DateTime date = DateTime.Parse(pubDate); // You may have to specify your own format
    DateTime date2 = DateTime.ParseExact(pubDate,"ddMMyyyy",System.Globalization.CultureInfo.Invarian‌​tCulture); // Like suggested by XenoPuTtSs
    // choose date or date2, according to your needs
    var entities = from a in dbcontext.Article
        where a.PubDateTime == date
        select a;
