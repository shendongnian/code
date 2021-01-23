    public class TimeSheet
    {
        public TimeSheet()
        {
            this.TimeSheetId = Guid.NewGuid()
                                   .ToString();
        }
        public virtual Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public virtual Job Job { get; set; }
        public string JobId { get; set; }
        public string TimeSheetId { get; set; }
    }
    public class Employee
    {
        public Employee()
        {
            this.EmployeeId = Guid.NewGuid()
                                  .ToString();
        }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
        public virtual ICollection<Mail> MailsSent { get; set; }
    }
    public class Job
    {
        public Job()
        {
            this.JobId = Guid.NewGuid()
                             .ToString();
        }
        // One job will have one client
        public virtual Client Client { get; set; }
        public string ClientId { get; set; }
        public string JobId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        // A Job may have many time sheets
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
    }
    public class Client
    {
        public Client()
        {
            this.ClientId = Guid.NewGuid()
                                .ToString();
        }
        public string ClientId { get; set; }
        public string EmailAddress { get; set; }
        // A client can have many work packages / jobs.
        public virtual ICollection<Job> WorkPackages { get; set; }
        public virtual ICollection<Mail> Mails { get; set; }
    }
    public class Mail
    {
        public Mail()
        {
            this.MailId = Guid.NewGuid()
                              .ToString();
        }
        // A mail item will reference one client.
        public virtual Client Client { get; set; }
        public string ClientId { get; set; }
        public string MailId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string EmployeeId { get; set; }
        // A mail item will also originate from an employee
        public virtual Employee Employee { get; set; }
        // This doesn't belong here... as if it isn't 
        // being sent, then it wouldn't make sense to create 
        // create the email in the first place...
        // If you want to queue emails, rename the field to `IsSent`
        // 
        // public bool SendEmail { get; set; }
    }
    public class TimeSheetConfiguration : EntityTypeConfiguration<TimeSheet>
    {
        public TimeSheetConfiguration()
        {
            this.ToTable("TimeSheets");
            
            this.HasKey(timeSheet => timeSheet.TimeSheetId);
            this.Property(property => property.TimeSheetId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(property => property.JobId)      .IsRequired();
            this.Property(property => property.EmployeeId) .IsRequired();
            this.HasRequired(timeSheet => timeSheet.Job)     .WithMany(job => job.TimeSheets).HasForeignKey(timeSheet => timeSheet.JobId);
            this.HasRequired(timeSheet => timeSheet.Employee).WithMany(emp => emp.TimeSheets).HasForeignKey(timeSheet => timeSheet.EmployeeId);
        }
    }
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            this.ToTable("Employees");
            this.HasKey(emp => emp.EmployeeId);
            this.Property(property => property.EmployeeId)  .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(property => property.FirstName)   .IsRequired();
            this.Property(property => property.LastName)    .IsOptional();
            this.Property(property => property.EmailAddress).IsRequired();
            this.HasMany(employee => employee.TimeSheets).WithRequired(time => time.Employee).HasForeignKey(time => time.EmployeeId);
            this.HasMany(employee => employee.MailsSent) .WithRequired(mail => mail.Employee).HasForeignKey(mail => mail.EmployeeId);
        }
    }
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            this.ToTable("Clients");
            this.HasKey(client => client.ClientId);
            this.Property(property => property.ClientId)    .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(property => property.EmailAddress).IsRequired();
            
            this.HasMany(property => property.WorkPackages).WithRequired(job  => job.Client) .HasForeignKey(job  => job.ClientId);
            this.HasMany(property => property.Mails)       .WithRequired(mail => mail.Client).HasForeignKey(mail => mail.ClientId);
        }
    }
    public class JobConfiguration : EntityTypeConfiguration<Job>
    {
        public JobConfiguration()
        {
            this.ToTable("Jobs");
            this.HasKey(job => job.JobId);
            this.Property(property => property.JobId)   .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(property => property.Name)    .IsRequired();
            this.Property(property => property.ClientId).IsRequired();
            this.Property(property => property.Notes)   .IsRequired();
            this.HasMany(job => job.TimeSheets).WithRequired(time => time.Job)             .HasForeignKey(time => time.JobId);
            this.HasRequired(job => job.Client).WithMany    (client => client.WorkPackages).HasForeignKey(job => job.ClientId);
        }
    }
    public class MailConfiguration : EntityTypeConfiguration<Mail>
    {
        public MailConfiguration()
        {
            this.ToTable("Mails");
            this.HasKey(mail => mail.MailId);
            this.Property(property => property.MailId)    .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(property => property.ClientId)  .IsRequired();
            this.Property(property => property.EmployeeId).IsRequired();
            this.Property(property => property.Subject)   .IsRequired();
            this.Property(property => property.Body)      .IsRequired();
            this.HasRequired(mail => mail.Client)  .WithMany(client => client.Mails)        .HasForeignKey(mail => mail.ClientId);
            this.HasRequired(mail => mail.Employee).WithMany(employee => employee.MailsSent).HasForeignKey(mail => mail.EmployeeId); 
        }
    }
    public class ExampleContext : DbContext
    {
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        ///             before the model has been locked down and used to initialize the context.  The default
        ///             implementation of this method does nothing, but it can be overridden in a derived class
        ///             such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        ///             is created.  The model for that context is then cached and is for all further instances of
        ///             the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///             property on the given ModelBuidler, but note that this can seriously degrade performance.
        ///             More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        ///             classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MailConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new TimeSheetConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
