    public BaseEntityConfig<T> : EntityTypeConfiguration<T> where T : BaseEntity<T>, new()
    {
    }
    public BaseEntity<T> where T : BaseEntity<T>, new()
    {
       //shared properties here
    }
    public BaseEntityMetaDataConfig : BaseEntityConfig<T> where T: BaseEntityWithMetaData<T>, new()
    {
        public BaseEntityWithMetaDataConfig()
        {
            this.HasOptional(e => e.RecCreatedBy).WithMany().HasForeignKey(p => p.RecCreatedByUserId);
            this.HasOptional(e => e.RecLastModifiedBy).WithMany().HasForeignKey(p => p.RecLastModifiedByUserId);
            
        }
    }
    public BaseEntityMetaData<T> : BaseEntity<T> where T: BaseEntityWithMetaData<T>, new()
    {
        #region Entity Properties
        public DateTime? DateRecCreated { get; set; }
        public DateTime? DateRecModified { get; set; }
        public long? RecCreatedByUserId { get; set; }
        public virtual User RecCreatedBy { get; set; }
        public virtual User RecLastModifiedBy { get; set; }
        public long? RecLastModifiedByUserId { get; set; }
        public DateTime? RecDateDeleted { get; set; }        
        #endregion
    }
    
        public PersonConfig()
        {
            this.ToTable("people");
            this.HasKey(e => e.PersonId);
            this.HasOptional(e => e.User).WithRequired(p => p.Person).WillCascadeOnDelete(true);
            this.HasOptional(p => p.Employee).WithRequired(p => p.Person).WillCascadeOnDelete(true);                
            this.HasMany(e => e.EmailAddresses).WithRequired(p => p.Person).WillCascadeOnDelete(true);
                        
            this.Property(e => e.FirstName).IsRequired().HasMaxLength(128);
            this.Property(e => e.MiddleName).IsOptional().HasMaxLength(128);
            this.Property(e => e.LastName).IsRequired().HasMaxLength(128);
        }
    }
    //I Have to use this pattern to allow other classes to inherit from person, they have to inherit from BasePeron<T>
    public class Person : BasePerson<Person>
    {
        //Just a dummy class to expose BasePerson as it is.
    }
    public class BasePerson<T> : BaseEntityWithMetaData<T> where T: BasePerson<T>, new()
    {
        #region Entity Properties       
        public long PersonId { get; set; } 
        public virtual User User { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<PersonEmail> EmailAddresses { get; set; }
        #endregion
        #region Entity Helper Properties
        [NotMapped]
        public PersonEmail PrimaryPersonalEmail
        {
            get
            {
                PersonEmail ret = null;
                if (this.EmailAddresses != null)
                    ret = (from e in this.EmailAddresses where e.EmailAddressType == EmailAddressType.Personal_Primary select e).FirstOrDefault();
                return ret;
            }
        }
        [NotMapped]
        public PersonEmail PrimaryWorkEmail
        {
            get
            {
                PersonEmail ret = null;
                if (this.EmailAddresses != null)
                    ret = (from e in this.EmailAddresses where e.EmailAddressType == EmailAddressType.Work_Primary select e).FirstOrDefault();
                return ret;
            }
        }
        private string _DefaultEmailAddress = null;
        [NotMapped]
        public string DefaultEmailAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_DefaultEmailAddress))
                {
                    PersonEmail personalEmail = this.PrimaryPersonalEmail;
                    if (personalEmail != null && !string.IsNullOrEmpty(personalEmail.EmailAddress))
                        _DefaultEmailAddress = personalEmail.EmailAddress;
                    else
                    {
                        PersonEmail workEmail = this.PrimaryWorkEmail;
                        if (workEmail != null && !string.IsNullOrEmpty(workEmail.EmailAddress))
                            _DefaultEmailAddress = workEmail.EmailAddress;
                    }
                }
                return _DefaultEmailAddress;
            }
        }
        #endregion
        #region Constructor
        static BasePerson()
        {            
        }
        public BasePerson()
        {
            this.User = null;
            this.EmailAddresses = new HashSet<PersonEmail>();
        }
        public BasePerson(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        #endregion
    }
    
