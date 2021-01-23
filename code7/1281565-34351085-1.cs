       public EntityMap()
        {
            this.Table(Entity);
            this.ID(p => p.EntityID);  // since the type of p does not have an "Entity" property
            this.Property(p => p.EntityName);
            this.Property(p => p.EntityFoundationDate);
        }
