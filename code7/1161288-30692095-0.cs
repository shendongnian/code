    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "Start Date")]
    public DateTime? StartDate { get; set; }
    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true), Display(Name = "Start Time")]
    public DateTime? StartTime { get; set; }
    [Display(Name = "Start Time")]
    public DateTime? FullStartTime
    {
        get
        {
            if(StartDate == null || StartTime == null) return null;
            
            return StartDate.Value.Date + StartTime.Value.TimeOfDay;
            //or return StartDate + StartTime;
        }
    }
