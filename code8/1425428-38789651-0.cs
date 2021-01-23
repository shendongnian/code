		private DateTime? _employmentStartDate;
		public DateTime? EmploymentStartDate
		{
			get
			{
				return _employmentStartDate != null ? TimeZoneInfo.ConvertTimeFromUtc(_employmentStartDate.Value, TimeZoneInfo.Local) : new DateTime();
			}
			set
			{
				_employmentStartDate = TimeZoneInfo.ConvertTimeToUtc((DateTime)value);
			}
		}
