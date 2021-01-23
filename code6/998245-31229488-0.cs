        public override int SaveChanges()
        {
            var added = this.ChangeTracker.Entries().Where(e => e.State == System.Data.EntityState.Added);
            // Do your thing, like changing the state to detached
            return base.SaveChanges();
        }
