    [Required]
            [Display(Name = "Date")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime DateAndTime { get; set; }
    
            //Display long date format
            public string DisplayDate
            {
                get
                {
                    // Sets the CurrentCulture property to U.S. English.
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    return (DateAndTime.ToLongDateString());
                }
            }
