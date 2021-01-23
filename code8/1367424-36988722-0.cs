    private DateTime _interviewTime;
	
	[Display(Name = "Interview Time")]
    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)] // Something here?
    public DateTime InterviewTime {
		get {
			return _interviewTime;
		}
		set {
			if (value.Minute != 0 || value.Second != 0 || value.Millisecond != 0) {
			    //either strip minutes/seconds/milliseconds or throw exception
            }
			_interviewTime = value;
		} 
	}
