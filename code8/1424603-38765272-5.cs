    private void AllCaseProgram(object args)
    {
        try
        {
            switch (numProcess)
            {
                case 0:
                    Parallel.ForEach(
                        dtUser.AsEnumerable(), 
                        items => BrowserTestRunner.Start(items["user"].ToString(), items["pass"].ToString()));
                    break;
                case 1:
                    ClickCart();
                    break;
                case 2:
                    Result();
                    break;
            }
        }
        catch (Exception ex)
        {
            if (browser != null)
                browser.Cleanup();
            numProcess = 0;
            AllCaseProgram(null);
        }
    }
