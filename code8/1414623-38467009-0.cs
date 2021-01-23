    public void Cycle()
    {
        CheckBox[] cboxes = null;
        if (host == false)
        {
            cboxes = relayRow.CheckBoxes;
        }                
        else if (host == true)
        {
            cboxes = relayRow2.CheckBoxes;
        }
        for (int i = 0; i < 16; i++)
        {            
            cboxes[i].Checked = true;
        }
    }
