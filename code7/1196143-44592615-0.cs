        [Display(Name="Display Date")]
        [DataType(DataType.Text)]
        public string DisplayDate
        {
            get
            {
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(_displayDate);
                return dt.ToShortDateString();
            }
            set { _displayDate = value; }
        }
