    public Int GetListIndex(string url)
    {
       LinkCollection links = browser.Links;
       int count = -1;
       foreach(Link lnk in links)
       {
          if(lnk.GetAttributeValue("href").Contains(url))
          {
             return ++count;
          }
         count++;
        }
     }
