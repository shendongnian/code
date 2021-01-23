    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonList1.SelectedItem.ToString()=="Single field scrambler" || RadioButtonList1.SelectedItem.ToString()=="singlefieldscrambler")
        {
           btnvcf.Enabled = false; 
           btnmcf.Enabled = false; 
           DropDownConfigFile.Enabled = false;
        }
    }
