    public static void GetVehicleByReleasedDate(Func<DBSet<Catalog>, IQueryable<Catalog>> query, Action<IQueryable<Catalog>> useQuery)
    {
        using (EntityDataModel context = new EntityDataModel())
        {
            useQuery(query(context.Catalog));
        }
    }
