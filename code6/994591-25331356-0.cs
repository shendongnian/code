    Process[] allopenexcel = Process.GetProcessesByName("EXCEL");
    if(allopenexcel.count==0)
    {
        isOpened = false;
        break;
    }
    else
    {
        foreach (System.Diagnostics.Process excl in allopenexcel)
        {
            Excel.Application exl = new Excel.Application();
            for (int i = 1; i <= exl.Workbooks.Count; i++)
            {
                if (exl.Workbooks(i).FullName == wbookname)
                {
                    isOpened = true;
                    break;
                }
            }
            exl.Quit();
        }
    }
   
