    private void btnSubmit_Click(object sender, EventArgs e)
    {
        CommonLogic();
    }
    
    private void axTws1_tickPrice(object sender, AxTWSLib._DTwsEvents_tickPriceEvent e)
    {    
        if (Condition)
        {
            CommonLogic();
        }
    }
    
    private void CommonLogic()
    {
        // code for common logic
    }
