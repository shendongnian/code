    public void LightUpCandles(int dayIndex)
    {
        firedmatch.Left = firedmatch.Left + 100;
        if(c == 1)
        {
            candle1.Visible = true;
        }
        if(c == 3 && dayIndex > 1)
        {
            candle2.Visible = true;
        }
        if(c == 5 && dayIndex > 2)
        {
            candle3.Visible = true;
        }
        if(c == 7 && dayIndex > 3)
        {
            candle4.Visible = true;
        }
        if(c == 11 && dayIndex > 4)
        {
            candle5.Visible = true;
        }
    }
