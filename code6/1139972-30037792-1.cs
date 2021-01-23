        public MyContainer(IApplication application) {
            _application = application;
        }
        public override int SaveChanges() {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            if (entities.Any()) {
                User currentUser = _application.GetCurrentUser();
                if (currentUser == null)
                    throw new Exception("Current user is undefined.");
                foreach (var entity in entities) {
                    BaseEntity baseEntity = (BaseEntity)entity.Entity;
                    DateTime time = DateTime.Now;
                    if (entity.State == EntityState.Added) {
                        baseEntity.Created = time;
                        baseEntity.CreatedBy = currentUser;
                    }
                    baseEntity.Modified = time;
                    baseEntity.ModifiedBy = currentUser;
                    // store the changed properties of the entity here
                    // ....
                }
            }
            return base.SaveChanges();
        }
