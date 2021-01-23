            using (ScaleManagerEntities SSDb = new ScaleManagerEntities())
            {
                TSS_Rack rack = SSDb.TSS_Rack.Where(r => r.rack_id == SelectedRack.rack_id).FirstOrDefault();
                foreach (TSS_Filter filter in Filters)
                {
                    filter.createdAt = DateTime.Now;
                    filter.isUsed = false;
                    filter.TSS_Rack = rack;
                    SSDb.TSS_Filter.Add(filter);
                }
                SSDb.SaveChanges();
            }
