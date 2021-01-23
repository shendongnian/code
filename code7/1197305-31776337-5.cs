        public static void GetVehicleByReleasedDate(Func<DbSet<Catalog>, IQueryable<dynamic>> query, Action<IQueryable<dynamic>> useQuery)
    {
        using (EntityDataModel context = new EntityDataModel())
        {
            useQuery(query(context.Catalog));
        }
    }
