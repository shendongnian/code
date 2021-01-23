    if (Master.MasterId != 0)
                    {
                        Dba.Entry(Master).State = EntityState.Modified;
                     }
        Dba.SaveChanges();
