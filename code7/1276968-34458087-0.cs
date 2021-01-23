        public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.Entity is ctTerminalTimeZone &&
                                    (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entity in selectedEntityList)
            {
                this.ctTerminalTimeZoneChangeLogEntities.Add(new ctTerminalTimeZoneChangeLog()
                {
                    DateModified = DateTime.Now.ToShortDateString(),
                    TerminalLocationCode = ((ctTerminalTimeZone)entity.Entity).TerminalLocationCode,
                    TimeModified = DateTime.Now.ToLongTimeString()
                });
                if (((ctTerminalTimeZone)entity.Entity).HiddenValue == null)
                {
                    this.Entry(((ctTerminalTimeZone)entity.Entity)).Property(x => x.HiddenValue).IsModified = false;
                }
                //and so on and so on
            }
            return base.SaveChanges();
        }
