            public EFDbContext()
                :base("EFDbContext")
            {
                this.Configuration.ProxyCreationEnabled = true;
                this.Configuration.LazyLoadingEnabled = false;
            }
