    using System.ComponentModel.DataAnnotations;
    [Required(ErrorMessage="[Education] Please enter the University of Institution.")]
    public string School
    {
		get { return _school; }
		set { _school = value; OnPropertyChanged();}
    }
