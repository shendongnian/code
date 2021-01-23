    List<int> lstSports = new List<int>();
            if(sport != null)
            {
                lstSports.Add(Convert.ToInt32(sport));
            }
            if (sport1 != null)
            {
                lstSports.Add(Convert.ToInt32(sport1));
            }
            if (lstSports.Count > 0)
            {
                foreach(int i in lstSports)
                {
                    if(lstSports.IndexOf(i) == 0)
                    {
                        predicate = predicate.And(x => x.SportsID == i);
                    }
                    else
                    {
                        predicate = predicate.Or(x => x.SportsID == i);
                    }
                }
            }
