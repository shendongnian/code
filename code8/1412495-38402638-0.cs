    foreach (var item2 in query2)
    {
       var y = new MU_By_Machine();
       y.Date = item2.Date;
       y.Shift = item2.Shift;
       y.Machine_Number = item2.Machine_Number;
       y.MU = item2.MU;
       if (item2.NWTotal > 0)
           y.MU_w_o_No_Work = (item2.MU * 8) / (8 - item2.NWTotal);
       else
           y.MU_w_o_No_Work = item2.MU;
       db.MU_By_Machines.Add(y);
    }
    db.SaveChanges();
