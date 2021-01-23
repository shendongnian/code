            foreach (DataRow row in DT2.Rows)
            {
                for (int i = 0; i < DT2.Rows.Count; i++)
                {
                    var Tjek = DT2.Rows[i][0];
                    if (list.Contains(DT2.Rows[i][0]))
                    {
                    }
                    else
                    {
                        
                        
                        list.Add(Tjek);
                    }
                   
                }
            }
        }
