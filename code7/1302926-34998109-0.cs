    for (int i = 0; i < 8; i++)
    {
        for (int j = 1; j < 4; j++)
        {
           //loop throught the table layout panels and dispose
           Control tlpTemp = tlpMaster.GetControlFromPosition(j, i);
           foreach(Control ctrl in tlpTemp.Controls)
           {
               while (ctrl.Controls.Count > 0)
                {
                    ctrl.Controls[0].Dispose();
                }
            }
         }
    }
