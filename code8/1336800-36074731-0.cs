    private void btnSubmit_Click(object sender, EventArgs e)
    {
        DoStuff();
    }
    
    private void axTws1_tickPrice(object sender, AxTWSLib._DTwsEvents_tickPriceEvent e)
    {    
        if (Condition)
        {
            DoStuff();
        }
    }
    private void DoStuff()
    {
        // code to do stuff common to both handlers
    }
