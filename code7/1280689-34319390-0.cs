    public void UpdateUnitAndRate(string units, string rate)
    {
        ItemId_LBL.Text = units;
        ItemName_TXT.Text = rate;
    }
    //put it in form2 as a field and new it up
    Form1 f1;
    
    //add this in the method or event you want to update units and rates in form1
    if (f1 != null)
       f1.UpdateUnitAndRate(units, rate);
    else
       f1 = new Form1(units, rate);
