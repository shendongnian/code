    for (int i = lTableLayoutRow; i < (lTableLayoutRow+ 3); i++)
    {
        RadioButton lRadBtn = new RadioButton();
        lPriority = i - lLayTblStRow + 1;
        lRadBtn.Name = "radP_" + lPriority.ToString();
        lRadBtn.Text = "Priority Level " + lPriority.ToString();
        lRadBtn.Anchor = AnchorStyles.Left;
        lRadBtn.Tag = i;
        lRadBtn.CheckedChanged +=(ss,ee)=>{
            selectedRadio = (int)((RadioButton)ss).Tag;
        };
        lLayoutTable.Controls.Add(lRadBtn);
        if (lPriority < 3)
        {
            lRadBtn.Checked = false;
        }
        else if(lPriority == 3)
        {
            lRadBtn.Checked = true;
        }
        lTableLayout.Controls.Add(lRadBtn, lTableLayoutColumn, i);
    }
