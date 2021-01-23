    private void axTws1_tickPrice(object sender, AxTWSLib._DTwsEvents_tickPriceEvent e)
    {    
        if (Condition)
        {
            button1_Click(sender, EventArgs.Empty);
        }
    }
