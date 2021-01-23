     static async Task<bool> StartExport()
        {
            using (var db = new Entities())
            {
                var appraisals = await db.Appraisals.ToListAsync();
                
                db.Database.CommandTimeout = 300;
                //Disabling auto detect changes enabled will bring some performance tweaks
                db.Configuration.AutoDetectChangesEnabled = false;
                foreach (var appraisal in appraisals.Where(g => g.Id > 1))
                {
                    if (appraisal.Id == 10)
                    {
                        appraisal.AppraisalName = "New name";
                        db.Entry(appraisal).State = EntityState.Added;
                    }
                    else
                    {
                        appraisal.AppraisalName = "Modified name";
                        db.Entry(appraisal).State = EntityState.Modified;
                    }
                }
                db.Configuration.AutoDetectChangesEnabled = true;
                if (await db.SaveChangesAsync() > 1)
                    return true;
                else
                    return false;
            }
        }
