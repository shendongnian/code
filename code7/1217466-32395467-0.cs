    [Column("AuthorisationStatus")]
    public byte AuthorisationStatusByte
    {
        get { return (byte) AuthorisationStatus; }
        set { AuthorisationStatus = (TriState) value; }
    }
