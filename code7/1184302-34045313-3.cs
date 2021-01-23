        public void Insert<TypeEntity>(TypeEntity entity) where TypeEntity: BaseEntity
        {
            var typesToRegister = typeof(DataContext).GetProperties().
                         Where(p => p.PropertyType == typeof(DbSet<TypeEntity>));
            
            var dbSetItem = typesToRegister.First();
            var methodAdd = dbSetItem.GetValue(this).GetType().GetMethod("Add");
            methodAdd.Invoke(dbSetItem.GetValue(this), new TypeEntity[] { entity });
            SaveChanges();
        }
