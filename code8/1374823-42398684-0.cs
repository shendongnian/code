    using Atlas.Data.Kernel;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using System;
    using Atlas.Core.Kernel.Extensions;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace Atlas.Data.EntityFramework.Kernel
    {
      public class PersistenceProvider<T> : IPersistenceProvider<T> where T : DatabaseObject<T>
      {
        public static readonly PersistenceProvider<T> Current = new PersistenceProvider<T>();
        public static readonly string DbSetProperyName = typeof(T).Pluralize();
        public static readonly PropertyInfo DbSetProperyInfo = typeof(DatabaseContext).GetProperty(DbSetProperyName);
    
        // C
        public void Insert(T item)
        {
          DatabaseOperation((databaseContext, collection) =>
          {
            collection.Add(item);
          },
          item.Inserting,
          item.Inserted
          );
        }
    
        // R
        public IEnumerable<T> Select(Func<T, bool> predicate = null)
        {
          using (var databaseContext = new DatabaseContext())
          {
            DbSet<T> collection = (DbSet<T>)DbSetProperyInfo.GetValue(databaseContext);
            return predicate != null ? collection.Where(predicate).ToList() : collection.ToList();
          }
        }
    
        // U
        public void Update(T item)
        {
          DatabaseOperation((databaseContext, collection) =>
          {
            collection.Attach(item);
            MarkModified(databaseContext, item);
          },
          item.Updating,
          item.Updated
          );
        }
    
        // D
        public void Delete(T item)
        {
          DatabaseOperation((databaseContext, collection) =>
          {
            collection.Attach(item);
            collection.Remove(item);
          },
          item.Deleting,
          item.Deleted
          );
        }
    
        private void MarkModified(DatabaseContext databaseContext, DatabaseObject<T> efObject)
        {
          databaseContext.Entry(efObject).State = efObject.Id != null ? EntityState.Modified : EntityState.Added;
          foreach (var pi in efObject.GetType().GetProperties().Where(pi => !pi.GetCustomAttributes(typeof(NotMappedAttribute), false).Any() && pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericArguments()[0].IsClass))
          {
            var col = (IEnumerable<T>)pi.GetValue(efObject);
            if (col != null)
              foreach (DatabaseObject<T> item in col)
                MarkModified(databaseContext, item);
          }
        }
    
        private DatabaseContext databaseContext = null;
        private void DatabaseOperation(Action<DatabaseContext, DbSet<T>> action, Action executing, Action executed)
        {
          bool outerOperation = databaseContext == null;
          try
          {
            if (outerOperation)
              databaseContext = new DatabaseContext();
            executing();
            DbSet<T> collection = (DbSet<T>)DbSetProperyInfo.GetValue(databaseContext);
            action(databaseContext, collection);
            executed();
            databaseContext.SaveChanges();
          }
          finally
          {
            if (outerOperation)
            {
              databaseContext.Dispose();
              databaseContext = null;
            }
          }
        }
    
      }
    }
