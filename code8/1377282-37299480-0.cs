            try
            {
                myContext.Configuration.AutoDetectChangesEnabled = false;
                var dataUpd = (from A in tempSS
                               from B in SDetails
                               from C in listTempInOut
                               where A.Id == B.Id
                               && A.Shift == B.Shift && A.Employee == C.Employee && A.SDate == C.Time_Date1
                               select new { A.SId, B.Status, C }).ToList();
                foreach (var row in dataUpd)
                {
                    row.C.Time_Field1 = row.ShiftId;
                    row.C.Time_Field2 = row.Status.ToString();
                }
            }
            finally
            {
                myContext.Configuration.AutoDetectChangesEnabled = true;
            }
