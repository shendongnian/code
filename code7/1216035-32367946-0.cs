    int newid = 0;
                try
                {
                    Database db = DatabaseFactory.CreateDatabase();
                    newid = (int)db.ExecuteScalar(
                        StoredProcedures.SaveInspectionPortNewReport,
                        inspection.InspectionStart)
                 }
