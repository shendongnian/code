        public override int SaveChanges()
        {
            
            int cveCount = ChangeTracker.Entries<CVE>().Where(argEntry => argEntry.State == EntityState.Added).Count();
            base.SaveChanges();
           
            return cveCount;
        }
