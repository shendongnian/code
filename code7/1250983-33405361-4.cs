    int i = 1;
    while (i <= lastPage && UrlList.Count <= setting_EPP)
    {
        System.Threading.Thread.Sleep(delay);
        load_page(standurl, i);
        if (i % 10 == 0) System.Threading.Thread.Sleep(delay);
        i++;
    }
    if (i <= lastPage && UrlList.Count > setting_EPP) table_populate(0);
    while (i <= lastPage)
    {
        System.Threading.Thread.Sleep(delay);
        load_page(standurl, i);
        if (i % 10 == 0) System.Threading.Thread.Sleep(delay);
        i++;
    }
