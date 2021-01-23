       public EntityMap()
        {
            this.Table(Entity);
            this.ID(p => p.Entity);
            this.Property(p => p.EntityName);
            this.Property(p => p.EntityFoundationDate);
        }
