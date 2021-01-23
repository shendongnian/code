            foreach (TDAPIOLELib.Release rl in listRel)
            {
                string RelStartDate = Convert.ToString(rl.StartDate);
                string RelEndDate = Convert.ToString(rl.EndDate);
                CycleFactory CyF = rl.CycleFactory;
                foreach (TDAPIOLELib.Cycle Cyc in CyF.NewList(""))
                 {
                        string CycleStartDate = Convert.ToString(Cyc.StartDate);
                        string CycleEndDate = Convert.ToString(Cyc.EndDate);
                 }
                
                
            }
