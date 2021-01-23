        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            DbInterception.Add(new SoftDeleteInterceptor());
        }
