    DataTable TabVal = new DataTable();
    for (double t = -0.025; t <= 0.025; t = t + 0.001)//theta[{t, -.05, .05, .001}]
                        {
                            TabVal.Rows.Add(RotTab.TabRot(t, i1));
                        }
     
