    using Blog.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    
    
    namespace Blog
    {
        public interface IData_Common
        {
            ObservableCollection<User> Users { get; }
            ObservableCollection<Other> Others { get; }
        }
    
    	public interface IData_InMemoryContext : IData_Common
        {
            IData_InMemoryContext Create();
        }
    
    	public class Data_InMemoryContext : IData_InMemoryContext
        {
            public ObservableCollection<User> Users { get; set; }
            public ObservableCollection<Other> Others { get; set; }
    
            public Data_InMemoryContext()
            {
                Users = new ObservableCollection<User>();
                Others = new ObservableCollection<Other>();
            }
    
            public IData_InMemoryContext Create()
            {
                Users = new ObservableCollection<User>();
                Others = new ObservableCollection<Other>();
    
                return new Data_InMemoryContext();
            }
    
        }
    
    	public interface IData_Context
        {
            DbSet<User> Users { get; set; }
            DbSet<Other> Others { get; set; }
    
            IData_Context Create();
        }
    
    	public class Data_Context : DbContext, IData_Context
        {
            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<Other> Others { get; set; }
            
    		public IData_Context Create()
            {
                return new Data_Context();
            }
    
            public Data_Context()
            {
                //this.Configuration.LazyLoadingEnabled = false;
            }
        }
    
        // I wrap context so that I can use the InMemoryContext interface
        public class WrapData_Context : IData_InMemoryContext
        {
            private object _Context;
            private DbSet<User> _Users;
            private DbSet<Other> _Others;
    
            public WrapData_Context(Data_Context DbContext)
            {
                if (DbContext is null)
                {
                    throw new NullReferenceException("DbContext can't be null");
                }
                _Context = DbContext;
                // Need to make sure the data is accessed so it is loaded to the local ObservableCollections
                DbContext.Users.ToList();
                _Users = DbContext.Users;
                DbContext.Others.ToList();
                _Others = DbContext.Others;
            }
    
            public IData_InMemoryContext Create()
            {
                var context = new Data_Context();
                return new WrapData_Context(context);
            }
    
            // Properties
                public ObservableCollection<User> Users => _Users.Local.ToObservableCollection();
                public ObservableCollection<Other> Others => _Others.Local.ToObservableCollection();
    
        }
    
    }
