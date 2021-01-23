        public string NextMeeting
        {
            get
            {
                return this.OdmMeetiings.Count > 0 
                        && this.OdmMeetiings.Any(x => x.Meeting.StartDate.Date > DateTime.Now.Date) ?
                        this.OdmMeetiings.Where(x => x.Meeting.StartDate.Date > DateTime.Now.Date).Min(x => x.Meeting.StartDate).ToShortDateString() 
                        : "-"; 
            }
        }
