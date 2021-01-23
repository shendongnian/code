    public void CleanExcelSheet()
    {
        new Thread(delegate()
        {
            for (int i = 0; i < 100000000; i++)
            {
                //... your cleaning here
                float _f = (float)i / 100000000;
                Session["percent"] = _f;
            }
        }).Start();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CleanExcelSheet();
    }
