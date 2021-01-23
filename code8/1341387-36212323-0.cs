    // this property will be persisted in the database, but can't be modified from outside
    public string SSN { get; private set; }
    // the attribute will make sure this doesn't get mapped to the db
    // this property uses the other property as a backing field with proper conversions
    [NotMapped]
    public string SSNDecrypted
    {
      get 
      {
        return MyEncryptionClass.Decrypt(this.SSN);
      }
      set
      {
        this.SSN =  MyEncryptionClass.Encrypt(value);
      }
    }
