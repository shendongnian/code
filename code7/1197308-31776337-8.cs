        public static void GetVehicleByReleasedDate(Func<DbSet<Catalog>, IQueryable<dynamic>> query, Action<IQueryable<dynamic>> useQuery)
        {
            using (EntityDataModel context = new EntityDataModel())
            {
                useQuery(query(context.Catalog));
            }
        }
        public static T GetVehicleByReleasedDate<T>(Func<DbSet<Catalog>, IQueryable<dynamic>> query, Func<IQueryable<dynamic>, T> useQuery)
        {
            using (EntityDataModel context = new EntityDataModel())
            {
                return useQuery(query(context.Catalog));
            }
        }
