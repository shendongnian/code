    [StringLength(3,
        ErrorMessageResourceType = typeof (Resources),
        ErrorMessageResourceName = "VALIDATION_ERROR_STRING_LENGTH_3"
        )]
    [Required(
        ErrorMessageResourceType = typeof (Resources),
        ErrorMessageResourceName = "VALIDATION_ERROR_ISO"
        )]
    public virtual string ISO
    {
        get { return iso; }
        set
        {
            iso = value;
            OnPropertyChanged("ISO");
        }
    }
