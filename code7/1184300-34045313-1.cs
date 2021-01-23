        public void Insert<TypeEntity>(TypeEntity entity) where TypeEntity: class
        {
            var typesToRegister = typeof(DataContext).GetProperties().
                         Where(p => p.PropertyType == typeof(DbSet<TypeEntity>));
            
            var dbSetItem = typesToRegister.First();
            var methodAdd = dbSetItem.GetValue(this).GetType().GetMethod("Add");
            methodAdd.Invoke(dbSetItem.GetValue(this), new TypeEntity[] { entity });
            SaveChanges();
        }
