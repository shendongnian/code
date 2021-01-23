    CREATE TABLE [dbo].[account](
    	[account_id] [int] IDENTITY(1,1) NOT NULL,
    	[name] [nvarchar](50) NOT NULL,
     CONSTRAINT [PK_dbo.account] PRIMARY KEY CLUSTERED 
    (
    	[account_id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    
    GO 
     
    
    CREATE TABLE [dbo].[address](
    	[address_id] [int] IDENTITY(1,1) NOT NULL,
    	[account_id] [int] NOT NULL,
    	[full_address] [nvarchar](256) NOT NULL,
     CONSTRAINT [PK_dbo.address] PRIMARY KEY CLUSTERED 
    (
    	[address_id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    
    GO
    
    ALTER TABLE [dbo].[address]  WITH CHECK ADD  CONSTRAINT [FK_dbo.address_dbo.account_account_id] FOREIGN KEY([account_id])
    REFERENCES [dbo].[account] ([account_id])
  
     using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks; 
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    
    
    
    
    
    /// <summary>
    /// Define my domain. 
    /// </summary> 
    public class Account
    {
        public Account()
        {
            this.Addresses = new List<Address>();
        }
        public int? AccountID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
    public class Address
    {
        public int? AddressID { get; set; }
        public int AccountID { get; set; }
        public string FullAddress { get; set; }
    }
    public interface IAccountService
    {
        Account GetAccount(int accountID);
        void SaveAccount(Account account);
    }
    public interface IAccountRepository
    {
        IQueryable<Account> GetAccounts();
        void UpdateAccount(Account account);
        void CreateAccount(Account account);
    }
    public class AccountService : IAccountService
    {
        private IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            this._repository = repository;
        }
        public Account GetAccount(int accountID)
        {
            //you can do some validation. for ex) if we pass the user's name, we can see if they have access rights to the system,  module, and data 
            return (from acc in this._repository.GetAccounts()
                    where acc.AccountID == accountID
                    select acc).FirstOrDefault();
        } 
        public void SaveAccount(Account account)
        {
            //apply your business rules such as validating the data, user access rights, and etc
            if (account.AccountID.HasValue)
            {
                this._repository.UpdateAccount(account);
            }
            else
            {
                this._repository.CreateAccount(account);
            }
        }
    }
    
    
    
    
    /// <summary>
    /// Data access layer.
    /// 
    /// This layer knows about your data saource such as sql server, oracle, or mongoDB.
    /// </summary>  
    public class AccountConfig : EntityTypeConfiguration<Account>
    {
        public AccountConfig() : base()
        {
            this.ToTable("account", "dbo")
                .HasKey(p => p.AccountID);
    
            this.Property(p => p.AccountID)
                .HasColumnName("account_id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
    
            this.Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();
    
            //define the relationship between account and address
            this.HasMany(p => p.Addresses).WithRequired().HasForeignKey(p => p.AccountID).WillCascadeOnDelete(false);
        }
    }
    public class AddressConfig : EntityTypeConfiguration<Address>
    {
        public AddressConfig() : base()
        {
            this.ToTable("address", "dbo")
                .HasKey(p => p.AddressID);
    
            this.Property(p => p.AddressID)
                .HasColumnName("address_id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
    
            this.Property(p => p.AccountID)
                .HasColumnName("account_id")
                .IsRequired();
    
            this.Property(p => p.FullAddress)
                .HasColumnName("full_address")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();
        }
    }
    public class AccountDBContext : DbContext
    {
        public AccountDBContext() : this("accountDB") { }
        public AccountDBContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            //I dont want to use any database initialization i.e create database if it doesnt exist
            //since your dev shop will have a deployment process, get use to the process of generating deployment scripts. 
            Database.SetInitializer<AccountDBContext>(null);
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        public IDbSet<Account> Accounts { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //map the domain types to the database tables using your database naming convention.
            modelBuilder.Configurations.Add(new AddressConfig());
            modelBuilder.Configurations.Add(new AccountConfig());
        }
    }
    
    //repository is on the data access layer, because it's coupled to EF and the context object.
    public class AccountRepository : IAccountRepository
    {
        private AccountDBContext _context;
        public AccountRepository()
        {
            this._context = new AccountDBContext();
        }
        public AccountRepository(string nameOrConnectionString)
        {
            this._context = new AccountDBContext(nameOrConnectionString);
        }
    
        public IQueryable<Account> GetAccounts()
        {
            return this._context.Accounts
                            .AsNoTracking()
                            .Include("Addresses");
        }
    
        public void CreateAccount(Account account)
        {
            this._context.Entry(account).State = EntityState.Added;
            this._context.SaveChanges();
        }
    
        public void UpdateAccount(Account account)
        {
            if (account.Addresses != null)
            {
                foreach (var addr in account.Addresses)
                {
                    if (addr.AddressID.HasValue)
                    {
                        this._context.Entry(addr).State = EntityState.Modified;
                    }
                    else
                    {
                        this._context.Entry(addr).State = EntityState.Added;
                    }
                }
            }
            this._context.Entry(account).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
    
    
    
    
    
    
    public class Program
    {
        public static void Main()
        {
            try
            {
                IAccountService service = new AccountService(new AccountRepository());
    
                //create new 
                var account = new Account()
                {
                    Name = "john doe"
                };
                account.Addresses.Add(new Address()
                {
                    FullAddress = "San Fran, CA"
                });
                account.Addresses.Add(new Address()
                {
                    FullAddress = "Texas"
                }); 
                service.SaveAccount(account);
    
                //get the account. I know the first accountID is one. I checked the database for testing.
                var savedAccount = service.GetAccount(1);
    
                //lets update it
                savedAccount.Name = "J. Doe";
                savedAccount.Addresses.Add(new Address()
                {
                    AccountID = savedAccount.AccountID.Value,
                    FullAddress = "Conn"
                });
    
                service.SaveAccount(savedAccount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
    }
