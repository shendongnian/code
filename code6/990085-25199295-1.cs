      protected override void OnLoad(EventArgs e)
      {
        string ktr, mtr;
        for (int k = 0; k < 24; k++)
        {
          for (int m = 0; m < 60; m = m + 5)
          {
            if (k < 10)
            {
                ktr = "0" + k.ToString();
            }
            else
            {
                ktr = k.ToString();
            }
            if (m < 10)
            {
                mtr = "0" + m.ToString();
            }
            else
            {
                mtr = m.ToString();
            }
            DropDownList1.Items.Add(new ListItem(ktr + ":" + mtr)); 
          }
       } 
    }
