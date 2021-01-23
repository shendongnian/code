     string tn = tt.GetType().FullName;
     // get reference to GetRepository<TEntity>
     var genericGet = uu.GetType().GetMethod("GetRepository").MakeGenericMethod(tt.GetType());
     // invoke to get IRepository<TEntity>
     var repository = genericGet.Invoke(uu, new object[] { tn});
     // get IRepository<TEntity>.Add
     var addMethod = repository.GetType().GetMethod("Add");
     // invoke
     addMethod.Invoke(repository, new object[] { tt});
