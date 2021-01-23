    public string mob {get; set; }
    [NotMapped]
    public string mobDecrypted
    {
        get
        {
            return mob.Decrypt();
        }
        set
        {
            mob = value.Encrypt();
        }
    }
