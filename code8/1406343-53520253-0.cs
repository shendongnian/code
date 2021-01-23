    public List<Models.EF.Inventarisatie.ScannerAanmelding> GetRecentSessions()
    {
        using (var db = new Models.EF.Inventarisatie.inventarisatieEntities())
        {
            var result = db.ScannerAanmelding
                .Where(sa => sa.FK_Inventarisatie_ID == MvcApplication.Status.Record.PK_Inventarisatie_ID)
                .GroupBy(sa => sa.FK_Scanner_ID)
                .Select(sa => sa.OrderByDescending(x => x.Moment).FirstOrDefault())
                .ToList();
            // make sure to disconnect entities before returning the results, otherwise, it will throw a 'Connection was disconnected before invocation result was received' error.
            result.ForEach((sa) => db.Entry(sa).State = System.Data.Entity.EntityState.Detached);
            return result;
        }
    }
