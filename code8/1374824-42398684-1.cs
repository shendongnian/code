    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    
    namespace Atlas.Data.Kernel
    {
      public class DatabaseObject<T> where T : DatabaseObject<T>
      {
    
        #region Constructors
        public DatabaseObject()
        {
          Id = Guid.NewGuid();
        } 
        #endregion
    
        #region Fields
    
        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }
    
        #endregion
    
        // C
        public virtual void Insert()
        {
          PersistenceProvider.Insert((T)this);
        }
    
        // R
        public static T SingleOrDefault(Guid Id)
        {
          return SingleOrDefault(o => o.Id == Id);
        }
    
        public static T SingleOrDefault(Func<T, bool> predicate)
        {
          return PersistenceProvider.Select(predicate).SingleOrDefault();
        }
    
        public static IEnumerable<T> Select(Func<T, bool> predicate = null)
        {
          return PersistenceProvider.Select(predicate);
        }
    
        // U
        public virtual void Update()
        {
          PersistenceProvider.Update((T)this);
        }
    
        // D
        public virtual void Delete()
        {
          PersistenceProvider.Delete((T)this);
        }
    
    
        #region Callbacks
        public virtual void Deleting() { }
        public virtual void Deleted() { }
        public virtual void Inserting() { }
        public virtual void Inserted() { }
        public virtual void Updating() { }
        public virtual void Updated() { }
        #endregion
    
        #region Static Properties
        private static IPersistenceProvider<T> persistenceProvider;
        [Dependency]
        public static IPersistenceProvider<T> PersistenceProvider
        {
          get
          {
            if(persistenceProvider == null)
            {
              var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = HttpContext.Current.Server.MapPath("~/bin/Atlas.Data.Kernel.dll.config") };
              Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
              var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
    
              var container = new UnityContainer().LoadConfiguration(unitySection);
              persistenceProvider = container.Resolve<IPersistenceProvider<T>>();
            }
            return persistenceProvider;
          }
          set => persistenceProvider = value;
        }
        #endregion
      }
    }
