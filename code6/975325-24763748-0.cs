    public static void UpdatePpsTransaction(IEnumerable<PpsTransaction> ppsTransaction)
    {
      using (var context = PpsEntities.DefaultConnection())
      {
        foreach (var trans in ppsTransaction)
        {
          context.Entry(trans).State = EntityState.Modified;
        }
        context.SaveChanges();
      }
    }
