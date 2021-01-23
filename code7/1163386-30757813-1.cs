    [Required(ErrorMessage = "You must enter the Name field.")]
    [StringLength(100, ErrorMessage = "That name is too long.")]
    public string Name
    {
        get { return name; }
        set { if (value != name) { name = value; NotifyPropertyChanged("Name", "Errors"); } }
    }
