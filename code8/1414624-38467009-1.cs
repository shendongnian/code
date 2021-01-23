    public void Cycle()
    {
        CheckBox[] cboxes = host ? relayRow2.CheckBoxes : relayRow.CheckBoxes;
        for (int i = 0; i < 16; i++)
        {            
             cboxes[i].Checked = true;
        }
    }
