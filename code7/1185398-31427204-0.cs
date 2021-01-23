    public static int UpsertData(SiteManagedRepairDetails obj)
            {
                
                XYZ.DBContexts.VoidsDBContext context = new XYZ.DBContexts.VoidsDBContext();
                var results = context.Database.ExecuteSqlCommand("p_XYZDetailsUpsert @RepairID, @RepairLineID"
                    , new SqlParameter("@RepairID", obj.RepairID)
                    , new SqlParameter("@RepairLineID", obj.RepairLineID)
                );
                return 0;
            }
 
