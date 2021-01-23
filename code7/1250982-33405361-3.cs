    int x = 1;
    load_page(standurl, 0);
    firstentryOnload = UrlList[0];
    if (UrlList.Count > setting_EPP) 
    {
        for (int i = 1; i <= lastPage; i++)
        {
            table_populate(0);
            System.Threading.Thread.Sleep(delay);
            load_page(standurl, i);
            if (x > 10)
            {
                //refresh firstpage,check for new data
                System.Threading.Thread.Sleep(delay);
                x = 1;
            }
            x++;
        }
    }
    else
    {
        for (int i = 1; i <= lastPage; i++)
        {
            System.Threading.Thread.Sleep(delay);
            load_page(standurl, i);
            if (x > 10)
            {
                //refresh firstpage,check for new data
                System.Threading.Thread.Sleep(delay);
                x = 1;
            }
            x++;
        }
    }
