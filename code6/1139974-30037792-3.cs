        public MyContainer(IUserProvider userProvider) {
            _userProvider = userProvider;
        }
        public override int SaveChanges() {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            if (entities.Any()) {
                User currentUser = _userProvider.GetCurrent();
                if (currentUser == null)
                    throw new Exception("Current user is undefined.");
                DateTime time = DateTime.Now;
                foreach (var entity in entities) {
                    BaseEntity baseEntity = (BaseEntity)entity.Entity;
                    if (entity.State == EntityState.Added) {
                        baseEntity.Created = time;
                        baseEntity.CreatedBy = currentUser;
                    }
                    baseEntity.Modified = time;
                    baseEntity.ModifiedBy = currentUser;
                    // get and store the changed properties of the entity here
                    // ....
                    var changeInfo = entities.Select(t => new { Original = t.OriginalValues.PropertyNames.ToDictionary(pn => pn, pn => originalValues[pn]), Current = t.CurrentValues.PropertyNames.ToDictionary(pn => pn, pn => t.CurrentValues[pn]);
        
                }
            }
            return base.SaveChanges();
        }
